using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Grid;
using System.Collections.Generic;


namespace Infrastructure
{
    public class SendEmail : ISendEmail
    {
        void ISendEmail.SendEmail(string from, string recipients, string subject, string body, string ID)
        {
            GeneratePDF(from,recipients,subject,body,ID);
          
        }

        public void GeneratePDF(string from, string recipients, string subject, string body, string ID)
        {
            //Generate a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to list.
            List<object> data = new List<object>();
            Object row1 = new { ID = "E01", Name = "Clay" };
            Object row2 = new { ID = "E02", Name = "Clay1" };
            Object row3 = new { ID = "E03", Name = "Clay2" };
            Object row4 = new { ID = "E04", Name = "Clay3" };
            Object row5 = new { ID = "E05", Name = "Clay4" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            data.Add(row4);
            data.Add(row5);
            //Add list to IEnumerable.
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
            //Write the PDF document to stream.
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);

            Attachment file = new Attachment(stream, "Attachment1.pdf", "application/pdf");
            //"dorcas.enjiru@outlook.com", "dorcaswawy@gmail.com", "Loan Installment Details", "Please find attached the loan installment details.", file

            _SendEMail("dorcas.enjiru@outlook.com", recipients, subject, body,file);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "Output.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            //return File(stream, contentType, fileName);

        }

        private void _SendEMail(string from, string recipients, string subject, string body, Attachment attachment)
        {
            //Creates the email message
            MailMessage emailMessage = new MailMessage(from, recipients);
            //Adds the subject for email
            emailMessage.Subject = subject;
            //Sets the HTML string as email body
            emailMessage.IsBodyHtml = false;
            emailMessage.Body = body;
            //Add the file attachment to this e-mail message.
            //emailMessage.Attachments.Add(attachment);-- tO UNCOMMENT
            //Sends the email with prepared message
            using (SmtpClient client = new SmtpClient())
            {
                //Update your SMTP Server address here
                client.Host = "smtp-mail.outlook.com";
                client.UseDefaultCredentials = false;
                //Update your email credentials here
                client.Credentials = new System.Net.NetworkCredential(from, "Test101.2023");
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(emailMessage);
            }
        }
    }

}
