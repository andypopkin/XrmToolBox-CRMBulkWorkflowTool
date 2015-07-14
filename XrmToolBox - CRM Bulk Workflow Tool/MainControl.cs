// PROJECT : XrmToolBox___CRM_Bulk_Workflow_Tool
// This project was developed by Tanguy Touzard
// CODEPLEX: http://xrmtoolbox.codeplex.com
// BLOG: http://mscrmtools.blogspot.com

using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using XrmToolBox;
using XrmToolBox.Attributes;

// If empty strings are left, default values are used
[assembly: BackgroundColor("")]
[assembly: PrimaryFontColor("")]
[assembly: SecondaryFontColor("")]
[assembly: SmallImageBase64("")]
[assembly: BigImageBase64("")]

namespace XrmToolBox___CRM_Bulk_Workflow_Tool
{
    public partial class MainControl : UserControl, IMsCrmToolsPluginUserControl
    {
        #region Variables

        /// <summary>
        /// Microsoft Dynamics CRM 2011 Organization Service
        /// </summary>
        private IOrganizationService service;

        /// <summary>
        /// Panel used to display progress information
        /// </summary>
        private Panel infoPanel;

        /// <summary>
        // Andy Popkin's Variables
        public EntityCollection _workflows = new EntityCollection();
        public EntityCollection _views = new EntityCollection();
        public EntityCollection ExecutionRecordSet = new EntityCollection();
        public Entity _selectedWorkflow;
        public Entity _selectedView;
        public Guid _defaultGuid = new Guid();

        public int emrCount = 0;
        public int errorCount = 0;
        public int emrBatchSize = 200;
        public ExecuteMultipleRequest requestWithResults;
        /// </summary>

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class <see cref="MainControl"/>
        /// </summary>
        public MainControl()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the organization service used by the tool
        /// </summary>
        public IOrganizationService Service
        {
            get { return service; }
        }

        /// <summary>
        /// Gets the logo to display in the tools list
        /// </summary>
        public Image PluginLogo
        {
            get { return toolImageList.Images[0]; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// EventHandler to request a connection to an organization
        /// </summary>
        public event EventHandler OnRequestConnection;

        /// <summary>
        /// EventHandler to close the current tool
        /// </summary>
        public event EventHandler OnCloseTool;

        #endregion EventHandlers

        #region Methods

        /// <summary>
        /// Updates the organization service used by the tool
        /// </summary>
        /// <param name="newService">Organization service</param>
        /// <param name="detail">Details of the connection</param>
        /// <param name="actionName">Action that requested a service update</param>
        /// <param name="parameter">Parameter passed when requesting a service update</param>
        public void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName = "", object parameter = null)
        {
            service = newService;

            if (actionName == "WhoAmI")
            {
                ProcessWhoAmI();
            }
        }

        private void BtnWhoAmIClick(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                ProcessWhoAmI();
            }
        }

        private void ProcessWhoAmI()
        {
            infoPanel = InformationPanel.GetInformationPanel(this, "Retrieving your user id...", 340, 100);

            var worker = new BackgroundWorker();
            worker.DoWork += WorkerDoWork;
            worker.ProgressChanged += WorkerProgressChanged;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            InformationPanel.ChangeInformationPanelMessage(infoPanel, e.UserState.ToString());
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var request = new WhoAmIRequest();
            var response = (WhoAmIResponse)service.Execute(request);

            ((BackgroundWorker)sender).ReportProgress(0, "Your used id has been retrieved!");

            e.Result = response.UserId;
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            infoPanel.Dispose();
            infoPanel.Dispose();
            Controls.Remove(infoPanel);

            MessageBox.Show(string.Format("You are {0}", (Guid)e.Result));
        }

        private void TsbCloseClick(object sender, EventArgs e)
        {
            if (OnCloseTool != null)
            {
                OnCloseTool(this, null);
            }
        }

        public virtual void ClosingPlugin(PluginCloseInfo info)
        {
            if (info.FormReason != CloseReason.None ||
                info.ToolBoxReason == ToolBoxCloseReason.CloseAll ||
                info.ToolBoxReason == ToolBoxCloseReason.CloseAllExceptActive)
            {
                return;
            }

            info.Cancel = MessageBox.Show(@"Are you sure you want to close this tab?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }

        #endregion Methods

        private void workflowsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainControl_Load_1(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                infoPanel = InformationPanel.GetInformationPanel(this, "Retrieving On-Demand Workflows...", 340, 100);

                var worker = new BackgroundWorker();
                worker.DoWork += WorkerLoadWorkflows;
                worker.ProgressChanged += WorkerProgressChanged;
                worker.RunWorkerCompleted += WorkerLoadWorkflowsCompleted;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
            }
        }

        private void WorkerLoadWorkflows(object sender, DoWorkEventArgs e)
        {
            getWorkflows();

            e.Result = _workflows;
        }

        private void WorkerLoadWorkflowsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            infoPanel.Dispose();
            infoPanel.Dispose();
            Controls.Remove(infoPanel);
        }

        private void cmbWorkflows_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                infoPanel = InformationPanel.GetInformationPanel(this, "Retrieving Views...", 340, 100);

                var worker = new BackgroundWorker();
                worker.DoWork += WorkerLoadViews;
                worker.ProgressChanged += WorkerProgressChanged;
                worker.RunWorkerCompleted += WorkerLoadViewsCompleted;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
            }
        }

        private void WorkerLoadViews(object sender, DoWorkEventArgs e)
        {
            getViews();

            e.Result = _views;
        }

        private void WorkerLoadViewsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            infoPanel.Dispose();
            infoPanel.Dispose();
            Controls.Remove(infoPanel);
        }

        private void cmbViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                infoPanel = InformationPanel.GetInformationPanel(this, "Counting Records in View...", 340, 100);

                var worker = new BackgroundWorker();
                worker.DoWork += WorkerGetCounts;
                worker.ProgressChanged += WorkerProgressChanged;
                worker.RunWorkerCompleted += WorkerGetCountsCompleted;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
            }
        }

        private void WorkerGetCounts(object sender, DoWorkEventArgs e)
        {
            GetRecordCount(((BackgroundWorker)sender));

            e.Result = ExecutionRecordSet.Entities.Count;
        }

        private void WorkerGetCountsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            infoPanel.Dispose();
            infoPanel.Dispose();
            Controls.Remove(infoPanel);
        }

        #region Helper Code

        private void getWorkflows()
        {
            #region Reset Variables

            ExecutionRecordSet.Entities.Clear();
            _workflows.Entities.Clear();
            _selectedWorkflow = null;
            _views.Entities.Clear();
            _selectedView = null;

            this.Invoke((MethodInvoker)delegate()
            {
                cmbWorkflows.Items.Clear();
                cmbViews.Items.Clear();
                txtRecordCount.Clear();
                rtxtFetchXML.Clear();
                radFetchXML.Checked = false;
                radViews.Checked = true;
                //progressBar1.Style = ProgressBarStyle.Marquee;
                txtBatch.Text = "200";
                emrBatchSize = 200;
            });

            #endregion Reset Variables

            #region Get Workflows Query

            QueryExpression query = new QueryExpression("workflow");
            query.ColumnSet.AddColumns("workflowid", "name", "primaryentity");
            query.Distinct = true;
            query.AddOrder("name", OrderType.Ascending);
            query.Criteria = new FilterExpression();
            //query.Criteria.AddCondition("category", ConditionOperator.Equal, 0);

            FilterExpression childFilter = query.Criteria.AddFilter(LogicalOperator.And);
            childFilter.AddCondition("category", ConditionOperator.Equal, 0);
            childFilter.AddCondition("activeworkflowid", ConditionOperator.NotNull);
            childFilter.AddCondition("ondemand", ConditionOperator.Equal, true);

            _workflows = service.RetrieveMultiple(query);
            if (_workflows.Entities.Count > 0)
            {
                foreach (var item in _workflows.Entities)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        cmbWorkflows.Items.Add(item["name"]);
                    });
                }
            }
            this.Invoke((MethodInvoker)delegate()
            {
                cmbWorkflows.Text = "Select a Workflow to run";
                cmbViews.Text = "Select a Workflow to populate this list";
                //progressBar1.Style = ProgressBarStyle.Continuous;
            });

            infoPanel.Dispose();
            infoPanel.Dispose();
            Controls.Remove(infoPanel);

            #endregion Get Workflows Query
        }

        private void getViews()
        {
            #region Reset View Stuff
            int selectedWorkflowIndex = 0;
            ExecutionRecordSet.Entities.Clear();
            Guid WorkflowId = Guid.Empty;
            _views.Entities.Clear();
            _selectedView = null;
            this.Invoke((MethodInvoker)delegate()
            {
                cmbViews.Items.Clear();
                rtxtFetchXML.Clear();
                radViews.Checked = true;
                radFetchXML.Checked = false;
                txtRecordCount.Clear();
                //progressBar1.Style = ProgressBarStyle.Marquee;
                selectedWorkflowIndex = cmbWorkflows.SelectedIndex;
            });
            #endregion Reset View Stuff

            _selectedWorkflow = _workflows[selectedWorkflowIndex];

            #region System Views Loop

            QueryExpression query = new QueryExpression("savedquery");
            query.ColumnSet.AllColumns = true;
            query.AddOrder("name", OrderType.Ascending);
            query.Criteria = new FilterExpression();
            //query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, workflowEntity);

            FilterExpression childFilter = query.Criteria.AddFilter(LogicalOperator.And);
            childFilter.AddCondition("querytype", ConditionOperator.Equal, 0);
            childFilter.AddCondition("returnedtypecode", ConditionOperator.Equal, _selectedWorkflow["primaryentity"]);
            childFilter.AddCondition("statecode", ConditionOperator.Equal, 0);
            childFilter.AddCondition("fetchxml", ConditionOperator.NotNull);

            EntityCollection _ManagedViews = service.RetrieveMultiple(query);
            _views.Entities.AddRange(_ManagedViews.Entities);

            foreach (var item in _ManagedViews.Entities)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    cmbViews.Items.Add(item["name"]);
                });
            }
            #endregion System Views Loop

            #region Personal View Divider
            //////////////////////////////////////////////////////////////////////////////
            this.Invoke((MethodInvoker)delegate()
            {
                cmbViews.Items.Add("---------------------Personal Views-----------------------");
            });
            Entity _dummyView = new Entity("userquery");
            _dummyView.Id = _defaultGuid;
            _dummyView["name"] = "Dummy View";

            _views.Entities.Add(_dummyView); ;
            //viewGuidList.Add(_viewCounter, _defaultGuid);
            //viewFetchList.Add(_defaultGuid, "Personal Views");
            //_viewCounter++;
            //////////////////////////////////////////////////////////////////////////////
            #endregion Personal View Divider

            #region Personal Views Loop
            QueryExpression query2 = new QueryExpression("userquery");
            query2.ColumnSet.AllColumns = true;
            query.AddOrder("name", OrderType.Ascending);
            query2.Criteria = new FilterExpression();
            //query.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, true);

            FilterExpression childFilter2 = query2.Criteria.AddFilter(LogicalOperator.And);
            childFilter2.AddCondition("querytype", ConditionOperator.Equal, 0);
            childFilter2.AddCondition("returnedtypecode", ConditionOperator.Equal, _selectedWorkflow["primaryentity"]);
            childFilter2.AddCondition("statecode", ConditionOperator.Equal, 0);
            childFilter2.AddCondition("fetchxml", ConditionOperator.NotNull);

            EntityCollection _UserViews = service.RetrieveMultiple(query2);
            _views.Entities.AddRange(_UserViews.Entities);

            foreach (var item in _UserViews.Entities)
            {
                //if (item.Attributes.Contains("fetchxml"))
                //{
                //viewGuidList.Add(_viewCounter, item.Id);
                //viewFetchList.Add(item.Id, item["fetchxml"].ToString());
                this.Invoke((MethodInvoker)delegate()
                {
                    cmbViews.Items.Add(item["name"]);
                });
                //_viewCounter++;
                //}
            }
            #endregion Personal Views Loop

            this.Invoke((MethodInvoker)delegate()
            {
                cmbViews.Text = "Select a View to run the workflow against";
                //progressBar1.Style = ProgressBarStyle.Continuous;
            });
        }

        private void GetRecordCount(object sender)
        {
            int _selectedViewIndex = 0;
            ExecutionRecordSet.Entities.Clear();
            string _fetchXML = "";
            string txtFetch = "";

            this.Invoke((MethodInvoker)delegate()
            {
                _selectedViewIndex = cmbViews.SelectedIndex;
                //button4.Enabled = false;
            });


            if (radFetchXML.Checked == true)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    txtFetch = rtxtFetchXML.Text;
                });

                _fetchXML = txtFetch;
            }
            else
            {
                _fetchXML = (String)_views[_selectedViewIndex]["fetchxml"];
            }

            var conversionRequest = new FetchXmlToQueryExpressionRequest
            {
                FetchXml = _fetchXML
            };
            var conversionResponse = (FetchXmlToQueryExpressionResponse)service.Execute(conversionRequest);

            QueryExpression query1 = conversionResponse.Query;
            query1.ColumnSet.Columns.Clear();

            //Console.Write("Looking for " + query.EntityName + "s.");
            query1.PageInfo = new PagingInfo();
            query1.PageInfo.PageNumber = 1;
            query1.PageInfo.PagingCookie = null;
            query1.PageInfo.Count = 5000;

            //int recordCounter = 0;
            while (true)
            {
                //Console.Write(".");
                EntityCollection results = service.RetrieveMultiple(query1);
                //writeit("Results Count: " + results.Entities.Count);

                ExecutionRecordSet.Entities.AddRange(results.Entities);
                ((BackgroundWorker)sender).ReportProgress(0, string.Format("Counting Records in View...({0})", ExecutionRecordSet.Entities.Count));

                //recordCount += results.Entities.Count();
                //foreach (var item in results.Entities)
                //{
                //ExecutionRecordSet.Entities.Add(item);
                //}

                // Check for more records, if it returns true.
                if (results.MoreRecords)
                {
                    //if (requestWithResults.Requests.Count > 0) { FlushEMR(); }
                    // Increment the page number to retrieve the next page.
                    query1.PageInfo.PageNumber++;
                    // Set the paging cookie to the paging cookie returned from current results.
                    query1.PageInfo.PagingCookie = results.PagingCookie;
                }
                else
                {
                    break;
                }
            }
            //writeit("Total Number of " + query.EntityName + "s : " + recordCounter);
            //return recordCounter;
            this.Invoke((MethodInvoker)delegate()
            {
                XDocument XDocument = XDocument.Parse(_fetchXML);
                rtxtFetchXML.Text = XDocument.ToString();
                //comboBox2Text = comboBox2.SelectedIndex;
                //button4.Enabled = true;
                txtRecordCount.Text = ExecutionRecordSet.Entities.Count.ToString();
            });


        }

        private void RunEMR(OrganizationRequest or, BackgroundWorker sender)
        {
            requestWithResults.Requests.Add(or);
            emrCount++;
            if (requestWithResults.Requests.Count >= emrBatchSize)
            {
                //emrCount += requestWithResults.Requests.Count;
                //writeit("Executing Multiple Workflows: " + requestWithResults.Requests.Count);
                ((BackgroundWorker)sender).ReportProgress(0, string.Format("Executing Workflows.. {0} of {1}", emrCount, ExecutionRecordSet.Entities.Count));
                this.Invoke((MethodInvoker)delegate()
                {
                    progressBar1.Maximum = ExecutionRecordSet.Entities.Count;
                    progressBar1.Value = emrCount;
                });

                ExecuteMultipleResponse emrsp = (ExecuteMultipleResponse)service.Execute(requestWithResults);
                HandleErrors(emrsp);

                //writeit("Total Workflows Started: " + (emrCount - errorCount) + " / " + ExecutionRecordSet.Entities.Count);
                requestWithResults.Requests.Clear();

                if (txtDelay.Text != "0")
                {
                    System.Threading.Thread.Sleep(Convert.ToInt16(txtDelay.Text) * 1000);
                }
            }
        }

        private void FlushEMR(BackgroundWorker sender)
        {
            if (emrCount > 0)
            {
                //emrCount += requestWithResults.Requests.Count;
                //writeit("Executing Multiple Workflows: " + requestWithResults.Requests.Count);
                ExecuteMultipleResponse emrsp = (ExecuteMultipleResponse)service.Execute(requestWithResults);
                HandleErrors(emrsp);
                requestWithResults.Requests.Clear();

                //if (errorCount > 0)
                //{
                //    writeit("Total Errors: " + errorCount);
                //}

                this.Invoke((MethodInvoker)delegate()
                {
                    progressBar1.Maximum = ExecutionRecordSet.Entities.Count;
                    progressBar1.Value = emrCount;
                });

                ((BackgroundWorker)sender).ReportProgress(0, string.Format("Executing Workflows.. {0] / {1}", emrCount, ExecutionRecordSet.Entities.Count));
                //writeit("Total Errors: " + errorCount);
                return;
            }
            else
            {
                MessageBox.Show("No records found in this view to process");
                return;
            }
        }

        private void HandleErrors(ExecuteMultipleResponse emrsp)
        {
            bool beep = true;
            foreach (var response in emrsp.Responses)
            {
                if (response.Fault != null)
                {
                    if (beep)
                    {
                        //Console.Beep();
                        beep = false;
                    }
                    errorCount++;
                    //writeit("(" + (emrCount - emrBatchSize) + response.RequestIndex + ")EMR Error: " + response.RequestIndex + ": " + response.Fault.Message);
                }
            }
        }

        #region FetchXML Stuff (for Paging Cookie)

        public string ExtractNodeValue(XmlNode parentNode, string name)
        {
            XmlNode childNode = parentNode.SelectSingleNode(name);

            if (null == childNode)
            {
                return null;
            }
            return childNode.InnerText;
        }

        public string ExtractAttribute(XmlDocument doc, string name)
        {
            XmlAttributeCollection attrs = doc.DocumentElement.Attributes;
            XmlAttribute attr = (XmlAttribute)attrs.GetNamedItem(name);
            if (null == attr)
            {
                return null;
            }
            return attr.Value;
        }

        public string CreateXml(string xml, string cookie, int page, int count)
        {
            StringReader stringReader = new StringReader(xml);
            XmlTextReader reader = new XmlTextReader(stringReader);

            // Load document
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            return CreateXml(doc, cookie, page, count);
        }

        public string CreateXml(XmlDocument doc, string cookie, int page, int count)
        {
            XmlAttributeCollection attrs = doc.DocumentElement.Attributes;

            if (cookie != null)
            {
                XmlAttribute pagingAttr = doc.CreateAttribute("paging-cookie");
                pagingAttr.Value = cookie;
                attrs.Append(pagingAttr);
            }

            XmlAttribute pageAttr = doc.CreateAttribute("page");
            pageAttr.Value = System.Convert.ToString(page);
            attrs.Append(pageAttr);

            XmlAttribute countAttr = doc.CreateAttribute("count");
            countAttr.Value = System.Convert.ToString(count);
            attrs.Append(countAttr);

            StringBuilder sb = new StringBuilder(1024);
            StringWriter stringWriter = new StringWriter(sb);

            XmlTextWriter writer = new XmlTextWriter(stringWriter);
            doc.WriteTo(writer);
            writer.Close();

            return sb.ToString();
        }
        #endregion


        #endregion Helper Code

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                infoPanel = InformationPanel.GetInformationPanel(this, "Counting Records in View...", 340, 100);

                var worker = new BackgroundWorker();
                worker.DoWork += WorkerGetCounts;
                worker.ProgressChanged += WorkerProgressChanged;
                worker.RunWorkerCompleted += WorkerGetCountsCompleted;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
            }
        }

        private void btnExecuteWFs_Click_1(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                infoPanel = InformationPanel.GetInformationPanel(this, "Executing Workflows...", 340, 100);

                var worker = new BackgroundWorker();
                worker.DoWork += WorkerExecWFs;
                worker.ProgressChanged += WorkerProgressChanged;
                worker.RunWorkerCompleted += WorkerExecWFsCompleted;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
            }
        }

        private void WorkerExecWFs(object sender, DoWorkEventArgs e)
        {
            execWFs(sender);
        }

        private void WorkerExecWFsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            infoPanel.Dispose();
            infoPanel.Dispose();
            Controls.Remove(infoPanel);
        }

        private void execWFs(object sender)
        {
            if (ExecutionRecordSet.Entities.Count <= 0)
            {
                MessageBox.Show("Please click 'Count Records' before Executing Workflows");
                return;
            }

            #region Bulk Data API Stuff
            // Create an ExecuteMultipleRequest object.
            requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = false
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };
            #endregion
            if (txtBatch.Text != "")
            {
                emrBatchSize = Convert.ToInt32(txtBatch.Text);
            }
            else
            {
                emrBatchSize = 200;
            }

            /*
            this.Invoke((MethodInvoker)delegate()
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripStatusLabel1.Text = "Executing Workflows";
                emrBatchSize = Convert.ToInt32(txtBatchSize.Text);
            });
            */

            foreach (var item in ExecutionRecordSet.Entities)
            {
                ExecuteWorkflowRequest _execWF = new ExecuteWorkflowRequest
                {
                    WorkflowId = _selectedWorkflow.Id,
                    EntityId = item.Id
                };
                RunEMR(_execWF, ((BackgroundWorker)sender));                
            }
            FlushEMR((BackgroundWorker)sender);

            /*
            this.Invoke((MethodInvoker)delegate()
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                toolStripStatusLabel1.Text = "Execution of Workflows Completed";
            });
            */
        }

        private void radFetchXML_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radViews_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void workflowsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                infoPanel = InformationPanel.GetInformationPanel(this, "Retrieving On-Demand Workflows...", 340, 100);

                var worker = new BackgroundWorker();
                worker.DoWork += WorkerLoadWorkflows;
                worker.ProgressChanged += WorkerProgressChanged;
                worker.RunWorkerCompleted += WorkerLoadWorkflowsCompleted;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
            }
        }

        private void viewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                infoPanel = InformationPanel.GetInformationPanel(this, "Retrieving Views...", 340, 100);

                var worker = new BackgroundWorker();
                worker.DoWork += WorkerLoadViews;
                worker.ProgressChanged += WorkerProgressChanged;
                worker.RunWorkerCompleted += WorkerLoadViewsCompleted;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                rtxtFetchXML.Clear();
                rtxtFetchXML.AppendText("** Ensure that the workflow you are attemtping to run is an 'On-Demand' workflow **");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("** When using FetchXML queries, you must 'Count Records' before you can Start Workflows **");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("** Any other issues/ideas, please contact Andy Popkin - andrewopopkin@gmail.com & @andypopkin on Twitter **");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
            });
        }


    }
}
