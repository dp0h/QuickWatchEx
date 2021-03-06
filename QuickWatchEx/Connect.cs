using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Windows.Forms;
using QuickWatchEx.QuickWatch;

namespace QuickWatchEx
{
    /// <summary>The object for implementing an Add-in.</summary>
    /// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2
    {
        /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
        public Connect()
        {
        }

        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
        /// <param term='application'>Root object of the host application.</param>
        /// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
        /// <param term='addInInst'>Object representing this Add-in.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;

            _dbgWatchConfig = new QuickWatchConfig();

            try {
                CommandBar commandBar = ((CommandBars)_applicationObject.CommandBars)["Code Window"];

                // Create Quick watch menu
                _controlQuickWatch = commandBar.Controls.Add(MsoControlType.msoControlButton, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, true);
                _controlQuickWatch.Caption = "QuickWatchEx...";
                _controlQuickWatch.Enabled = IsInDebugMode(_applicationObject);

                _menuItemHandlerQuickWatch = (CommandBarEvents)_applicationObject.Events.CommandBarEvents[_controlQuickWatch];
                _menuItemHandlerQuickWatch.Click += MenuItemHandlerQuickWatch_Click;

                _debuggerEvents = _applicationObject.Events.DebuggerEvents;
                _debuggerEvents.OnEnterDesignMode += DebuggerEvents_OnEnterDesignMode;
                _debuggerEvents.OnEnterBreakMode += DebuggerEvents_OnEnterBreakMode;
                _debuggerEvents.OnEnterRunMode += DebuggerEvents_OnEnterRunMode;
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
            _controlQuickWatch.Delete();
        }

        /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        /// <summary>
        /// Debug event handler
        /// </summary>
        /// <param name="Reason"></param>
        protected void DebuggerEvents_OnEnterDesignMode(dbgEventReason Reason) {
            _controlQuickWatch.Enabled = false;
        }

        /// <summary>
        /// Debug event handler
        /// </summary>
        /// <param name="Reason"></param>
        /// <param name="ExecutionAction"></param>
        protected void DebuggerEvents_OnEnterBreakMode(dbgEventReason Reason, ref dbgExecutionAction ExecutionAction) {
            _controlQuickWatch.Enabled = true;
        }

        /// <summary>
        /// Debug event handler
        /// </summary>
        /// <param name="Reason"></param>
        protected void DebuggerEvents_OnEnterRunMode(dbgEventReason Reason) {
            _controlQuickWatch.Enabled = false;
        }

        /// <summary>
        /// Button handler
        /// </summary>
        /// <param name="CommandaBarControl"></param>
        /// <param name="handled"></param>
        /// <param name="cancelDefault"></param>
        protected void MenuItemHandlerQuickWatch_Click(object CommandaBarControl, ref bool handled, ref bool cancelDefault) {
            if (!IsInDebugMode(_applicationObject)) {
                MessageBox.Show("Not in Debug mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                string expression = string.Empty;
                if (_applicationObject.ActiveDocument != null) {
                    // Check if selected text is an expression
                    var textDocument = (TextDocument)_applicationObject.ActiveDocument.Object("");
                    var textSelection = textDocument.Selection;
                    if (!String.IsNullOrEmpty(textSelection.Text) && CheckExpression(textSelection.Text, _applicationObject)) {
                        expression = textSelection.Text;
                    }
                }

                if (string.IsNullOrEmpty(expression)) {
                    // Get closest valid expression
                    if (_applicationObject.ActiveDocument != null) {
                        var textDocument = (TextDocument)_applicationObject.ActiveDocument.Object("");
                        var virtualPoint = textDocument.Selection.ActivePoint;
                        var editPoint = textDocument.StartPoint.CreateEditPoint();
                        var text = editPoint.GetText(textDocument.EndPoint.CreateEditPoint());

                        expression = GetClosestVariable(text, virtualPoint.Line, virtualPoint.VirtualCharOffset);
                    }
                    if (!string.IsNullOrEmpty(expression) && !CheckExpression(expression, _applicationObject)) {
                        expression = string.Empty;
                    }
                }

                var watch = new EnvDteDebugControllerBase(_applicationObject, expression, _dbgWatchConfig);
                var dialog = new QuickWatch.QuickWatch(watch, expression);

                dialog.ShowDialog();
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            handled = true;
        }

        /// <summary>
        /// Checks if VS in Debug mode
        /// </summary>
        /// <param name="dte"></param>
        /// <returns></returns>
        private bool IsInDebugMode(DTE2 dte) {
            if (dte == null || dte.Debugger == null) {
                return false;
            }
            return dte.Debugger.CurrentMode == dbgDebugMode.dbgBreakMode;
        }

        /// <summary>
        /// Check if the expression is valid
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="dte"></param>
        /// <returns></returns>
        private bool CheckExpression(string expression, DTE2 dte) {
            if (expression == "") {
                return false;
            }
            var expr = dte.Debugger.GetExpression(expression);
            return expr != null && expr.IsValidValue;
        }

        /// <summary>
        /// Searches for a valid expression around the cursor.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="line"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private string GetClosestVariable(string str, int line, int pos) {
            var ln = str.Split('\n')[line - 1];
            pos--;

            int endPosition = pos;
            if (ln[endPosition] == '.') {
                endPosition++;
            }

            while (endPosition < ln.Length && ((ln[endPosition] >= 'A' && ln[endPosition] <= 'Z') || (ln[endPosition] >= 'a' && ln[endPosition] <= 'z') ||
                (ln[endPosition] >= '0' && ln[endPosition] <= '9') || ln[endPosition] == '_')) {
                endPosition++;
            }

            var startPosition = pos;
            while (startPosition - 1 > 0 && ((ln[startPosition - 1] >= 'A' && ln[startPosition - 1] <= 'Z') || (ln[startPosition - 1] >= 'a' && ln[startPosition - 1] <= 'z') ||
                (ln[startPosition - 1] >= '0' && ln[startPosition - 1] <= '9') || ln[startPosition - 1] == '_' || ln[startPosition - 1] == '.')) {
                startPosition--;
            }

            return ln.Substring(startPosition, endPosition - startPosition);
        }

        #region Private members

        private DTE2 _applicationObject;
        private AddIn _addInInstance;
        private QuickWatchConfig _dbgWatchConfig;
        private DebuggerEvents _debuggerEvents;
        private CommandBarEvents _menuItemHandlerQuickWatch;
        private CommandBarControl _controlQuickWatch;

        #endregion
    }
}