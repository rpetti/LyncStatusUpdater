using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Lync.Model;

namespace LyncStatusUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = LyncClient.GetClient();

            if (client.State.ToString() == "SignedIn")
            {
                var contactInfo = new Dictionary<PublishableContactInformationType, object>();
                for (var i=0; i<args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-Away":
                            contactInfo.Add(PublishableContactInformationType.Availability, ContactAvailability.Away);
                            break;
                        case "-Available":
                            contactInfo.Add(PublishableContactInformationType.Availability, ContactAvailability.Free);
                            break;
                        case "-Busy":
                            contactInfo.Add(PublishableContactInformationType.Availability, ContactAvailability.Busy);
                            break;
                        case "-DoNotDisturb":
                            contactInfo.Add(PublishableContactInformationType.Availability, ContactAvailability.DoNotDisturb);
                            break;
                        case "-Status":
                            contactInfo.Add(PublishableContactInformationType.PersonalNote, args[i + 1]);
                            break;
                    }
                }
                var pub = client.Self.BeginPublishContactInformation(contactInfo, null, null);
                client.Self.EndPublishContactInformation(pub);
            }
        }
    }
}
