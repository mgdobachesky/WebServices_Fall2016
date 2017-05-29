using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Dobachesky_Assn1
{
    public partial class Form1 : Form
    {
        int contactIndex = -1;

        public Form1()
        {
            InitializeComponent();

            //run a function that fills in the version information from the xml document
            versionInformation();

            //run a function that fills in the information for the first contact in the xml document
            fillFirstContact();
        }

        //function that gets the version information from the xml document
        private void versionInformation()
        {
            //put the path to the file in a string
            string fileName = Application.StartupPath + "\\contacts.xml";
            //create a new instance of the XmlDocument class
            XmlDocument xmlDoc = new XmlDocument();
            //load the stored file into the XmlDocument Class
            xmlDoc.Load(fileName);
            //get the root node of the xml document
            XmlElement elm = xmlDoc.DocumentElement;

            //create a node list for the version date and version number
            XmlNodeList versionDate = xmlDoc.GetElementsByTagName("versionDate");
            XmlNodeList versionNumber = xmlDoc.GetElementsByTagName("versionNumber");

            //display the information from those two tags in a label 
            //using foreach because an array was returned
            foreach(XmlNode node in versionDate)
            {
                lblVersionDate.Text += node.InnerText;
            }

            foreach (XmlNode node in versionNumber)
            {
                lblVersionNumber.Text += node.InnerText;
            }
        }

        private void fillFirstContact()
        {
            //set the contact index to the first contact
            contactIndex = 0;

            //store the file name in a string
            string fileName = Application.StartupPath + "\\contacts.xml";
            //create a new xml document
            XmlDocument xmlDoc = new XmlDocument();
            //load the stored file into the xml document
            xmlDoc.Load(fileName);

            //create an XmlNodeList from the contacts in the xml document
            XmlNodeList contactInfo = xmlDoc.GetElementsByTagName("contact");

            //fill in the information on the windows form
            txtFirstName.Text = contactInfo[contactIndex].ChildNodes[0].InnerText;
            txtLastName.Text = contactInfo[contactIndex].ChildNodes[1].InnerText;
            txtPhoneNumber.Text = contactInfo[contactIndex].ChildNodes[2].InnerText;
            txtFaxNumber.Text = contactInfo[contactIndex].ChildNodes[3].InnerText;
            txtEmailAddress.Text = contactInfo[contactIndex].ChildNodes[4].InnerText;
            if (contactInfo[contactIndex].Attributes[0].InnerText == "male")
            {
                rdoMale.Checked = true;
                rdoFemale.Checked = false;
            }
            else if (contactInfo[contactIndex].Attributes[0].InnerText == "female")
            {
                rdoMale.Checked = false;
                rdoFemale.Checked = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //go to the previous contact
            contactIndex--;

            //store the file name into a string
            string fileName = Application.StartupPath + "\\contacts.xml";
            //create a new xml document
            XmlDocument xmlDoc = new XmlDocument();
            //if there are no previous contacts, reset the index to the first contact
            if (contactIndex < 0)
            {
                contactIndex = 0;
            }

            //load the xml document using the stored string
            xmlDoc.Load(fileName);
            //get a node list of the contact tags
            XmlNodeList contactInfo = xmlDoc.GetElementsByTagName("contact");

            //fill in the windows form using the index of the selected contact
            txtFirstName.Text = contactInfo[contactIndex].ChildNodes[0].InnerText;
            txtLastName.Text = contactInfo[contactIndex].ChildNodes[1].InnerText;
            txtPhoneNumber.Text = contactInfo[contactIndex].ChildNodes[2].InnerText;
            txtFaxNumber.Text = contactInfo[contactIndex].ChildNodes[3].InnerText;
            txtEmailAddress.Text = contactInfo[contactIndex].ChildNodes[4].InnerText;
            if (contactInfo[contactIndex].Attributes[0].InnerText == "male")
            {
                rdoMale.Checked = true;
                rdoFemale.Checked = false;
            }
            else if (contactInfo[contactIndex].Attributes[0].InnerText == "female")
            {
                rdoMale.Checked = false;
                rdoFemale.Checked = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //increment the contact index of the contact to be selected
            contactIndex++;

            //store the file location and name in a string
            string fileName = Application.StartupPath + "\\contacts.xml";
            //create a new instance of the XmlDocument class
            XmlDocument xmlDoc = new XmlDocument();
            //load the xml document that was stored earlier using the blank xml document object that was just created
            xmlDoc.Load(fileName);

            //find the number of contacts in the xml documents
            //if the selected index is too high, reset it to the last contact in the xml document
            XmlNodeList contactsQuantity = xmlDoc.GetElementsByTagName("contact");
            if (contactIndex >= contactsQuantity.Count)
            {
                contactIndex = contactsQuantity.Count - 1;
            }

            //create a list of the contact nodes to be read from
            XmlNodeList contactInfo = xmlDoc.GetElementsByTagName("contact");

            //fill in the windows form using the selected contact index
            txtFirstName.Text = contactInfo[contactIndex].ChildNodes[0].InnerText;
            txtLastName.Text = contactInfo[contactIndex].ChildNodes[1].InnerText;
            txtPhoneNumber.Text = contactInfo[contactIndex].ChildNodes[2].InnerText;
            txtFaxNumber.Text = contactInfo[contactIndex].ChildNodes[3].InnerText;
            txtEmailAddress.Text = contactInfo[contactIndex].ChildNodes[4].InnerText;
            if (contactInfo[contactIndex].Attributes[0].InnerText == "male")
            {
                rdoMale.Checked = true;
                rdoFemale.Checked = false;
            }
            else if (contactInfo[contactIndex].Attributes[0].InnerText == "female")
            {
                rdoMale.Checked = false;
                rdoFemale.Checked = true;
            }
        }
    }
}
