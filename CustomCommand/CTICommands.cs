using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using Genesyslab.Desktop.Modules.Core.Model.Agents;
using Genesyslab.Enterprise.Services;
using Genesyslab.Platform.ApplicationBlocks.Commons.Protocols;
using Genesyslab.Platform.ApplicationBlocks.WarmStandby;
using Genesyslab.Platform.Commons.Connection.Configuration;
using Genesyslab.Platform.Commons.Protocols;
using Genesyslab.Platform.Voice.Protocols;
using Genesyslab.Platform.Voice.Protocols.TServer;
using Genesyslab.Platform.Voice.Protocols.TServer.Events;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Agent;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Dn;
using Genesyslab.Platform.Voice.Protocols.TServer.Requests.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Genesyslab.Desktop.Modules.ExtensionSample.Commands
{
    public partial class CTICommands 
    {

        // We retrieve this information from EventDialing or EventRinging events.
        public static string phoneNumber;
        public static string callID;                    // connID is only present during an active call       
        #region Constants
        // Host and port to connect to Genesys Server
        private static String HOST = "10.220.56.10";
        private const int PORT = 3000;
        // private const String BACKUP_HOST = "sscim0121";
        // private const int BACKUP_PORT = 6004;

        private const String CLIENT_NAME = "SIP_p";

        //private const String AGENT_ID = "mrabie";

        private String DN = ExtensionSampleModule.agentDN;
        //private const String PASSWORD = "123";
        private const String QUEUE = "";
        #endregion
        
        #region Private Members 

        private TServerProtocol protocol;
        //private WarmStandbyService warmStandbyService;

        //private ConnectionId secondConnID;              // secondConnID is only present during a consultative call
        //private String thisDN;                          // DN on which Event has occurred

        #endregion
  

        public CTICommands()
        {
            InitializePSDKProtocolAndAppBlocks();
        }
        private void InitializePSDKProtocolAndAppBlocks()
        {
            MessageBox.Show("sip");
            try
            {
                #region ADDP settings
                PropertyConfiguration config = new PropertyConfiguration();
                config.UseAddp = true;
                config.AddpServerTimeout = 30;
                config.AddpClientTimeout = 60;
                //config.AddpTrace = "both";
                config.AddpTraceMode = AddpTraceMode.Both;
                #endregion

                Endpoint endpoint = new Endpoint(HOST, PORT, config);
                //Endpoint backupEndpoint = new Endpoint(BACKUP_HOST, BACKUP_PORT, config);

                protocol = new TServerProtocol(endpoint);
                protocol.ClientName = CLIENT_NAME;
                protocol.BeginOpen();

                Register();
                //Connect();
                //logging();
                //AnswerCall();

                #region Setup Warmstandby
                // WarmStandbyConfiguration warmStandbyConfig = new WarmStandbyConfiguration(endpoint, backupEndpoint);
                //warmStandbyConfig.Timeout = 5000;
                //warmStandbyConfig.Attempts = 2;

                //warmStandbyService = new WarmStandbyService(protocol);
                // warmStandbyService.ApplyConfiguration(warmStandbyConfig);
                //warmStandbyService.Start();
                #endregion

                //protocol.Opened += new EventHandler(OnProtocolOpened);
                //protocol.Closed += new EventHandler(OnProtocolClosed);

                protocol.Received += new EventHandler(OnMessageReceived);
                protocol.Error += new EventHandler(OnProtocolError);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

        }

    
        private void OnProtocolError(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());
        }
        private void OnMessageReceived(object sender, EventArgs e)
        {
                var message = ((MessageEventArgs)e).Message;

                // your event-handling code goes here
                switch (message.Id)
                {
                    case EventEstablished.MessageId:
                        var eventEstablished = message as EventEstablished;
                        callID = eventEstablished.CallUuid;
                        MessageBox.Show(callID.ToString());
                        phoneNumber = eventEstablished.ANI;
                        MessageBox.Show(phoneNumber);
                        break;
                }
          
        }

        private void OnProtocolClosed(object sender, EventArgs e)
        {
            //Connect();
            //MessageBox.Show("closed");
        }

        private void OnProtocolOpened(object sender, EventArgs e)
        {
            //MessageBox.Show("opened");
            //protocol.BeginOpen();
        }

        private void Connect()
        {
            // Open the connection - only when the connection is not already opened
            // Opening the connection can fail and raises an exception
            try
            {

                if (protocol.State == ChannelState.Closed)
                    protocol.BeginOpen(); // attempt to open the channel asynchronously

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "\n" + ex.StackTrace + "\n");
            }
        }
        private void LogMessage(String message)
        {
            Console.Write(">> INCOMING \r\n\r\n" + message.Replace("\n", "\r\n") + "\r\n************************************\r\n");

        }
        private void LogRequest(String request)
        {
            Console.Write("<< OUTGOING \r\n\r\n" + request.Replace("\n", "\r\n") + "\r\n************************************\r\n");

        }
        private void LogException(Exception e)
        {
            Console.Write(e.Message + "\r\n" + e.StackTrace + "\r\n");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //CTICommands cti = new CTICommands();

            //cti.Connect();
            //cti.Register();
            //System.Windows.Forms.Application.Exit();
            //cti.AnswerCall();

        }

        //public void logging()
        //{
        //    try
        //    {

        //        RequestAgentLogin requestAgentLogin =
        //            RequestAgentLogin.Create(
        //            DN,
        //            AgentWorkMode.AutoIn);


        //        requestAgentLogin.ThisQueue = QUEUE;
        //        // Your switch may not need a user name and password:
        //        requestAgentLogin.AgentID = AGENT_ID;
        //        requestAgentLogin.Password = PASSWORD;
        //        IMessage response = protocol.Request(requestAgentLogin);
        //    }
        //    catch (Exception e)
        //    {
        //        LogException(e);
        //    }
        //}
        //public void AnswerCall()
        //{
        //    try
        //    {
        //        RequestAnswerCall requestAnswerCall =
        //            RequestAnswerCall.Create(
        //            DN,
        //            connID);          // Type of call being made

        //        MessageBox.Show(connID.ToString());

        //        LogRequest(requestAnswerCall.ToString());

        //        IMessage response = protocol.Request(requestAnswerCall);

        //        switch (response.Id)
        //        {
        //            case EventEstablished.MessageId:
        //                var eventEstablished = response as EventEstablished;
        //                connID = eventEstablished.ConnID;
        //                MessageBox.Show(connID.ToString());
        //                phoneNumber = eventEstablished.ANI;
        //                MessageBox.Show(phoneNumber);
        //                break;

        //        }
        //        // Request asynchronously
        //        //protocol.Request(requestAnswerCall);

        //    }
        //    catch (Exception e)
        //    {
        //        LogException(e);
        //    }
        //}

        public void Register()
        {
            try
            {
                MessageBox.Show("Register");
                MessageBox.Show(DN);
               // Create the register address request object for TServer (Voice Platform SDK). 
               RequestRegisterAddress request =
                    RequestRegisterAddress.Create(
                    DN,                               // DN to register
                    RegisterMode.ModeShare,             // Share DN info with other apps?
                    ControlMode.RegisterDefault,        // Register DN with switch?
                    AddressType.DN);                    // Type of DN

                //LogRequest(request.ToString());

                IMessage response = protocol.Request(request);

                //protocol.Send(request);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
