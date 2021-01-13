﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Web;

namespace IAIWebApp.Models
{
    public class SendMail
    {
        public void SendMailWithAttachment()
        {
            string body = "<html><head>" +
                    "<title></title> " +
                    "<style type='text/css'>" +
                    "@font-face { font - family: 'gillsans_r'; src: url('/_ui/fonts/GillSans/GillSans-Regular.ttf'); }" +
                    "@font-face { font - family: 'avenir_bold'; font - style: bold; font - weight: 800; src: url('/_ui/fonts/Avenir/Avenir-Heavy-05.ttf'); }" +
                    "@font-face { font - family: 'gillsans_sb'; font - style: normal; font - weight: 600; src: url('/_ui/fonts/GillSans/GillSans-SemiBold.ttf'); }" +
                    "@font-face { font - family: 'avenir_light'; font - style: normal; font - weight: 200; src: url('/_ui/fonts/Avenir/Avenir-Light-07.ttf'); }" +
                    "@font-face { font - family: 'gillsans_light'; src: url('/_ui/fonts/GillSans/GillSans-Light.ttf'); }" +
                    "@font-face { font - family: 'gillsans_sb'; font - style: normal; font - weight: 600; src: url('/_ui/fonts/GillSans/GillSans-SemiBold.ttf'); }" +
                    "@font-face { font - family: 'Antro_Vectra'; src: url('/_ui/fonts/AntroVectra/Antro_Vectra.otf'); }" +
                    "@font-face { font - family: 'avenir_black_r'; font - style: normal; font - weight: 400; src: url('/_ui/fonts/Avenir/Avenir-Black-03.ttf'); }" +
                    "@font-face { font - family: 'Helvetica'; font - style: normal; font - weight: 400; src: url('/_ui/fonts/Helvetica/Helvetica.ttf'); }" +
                    "@font-face { font - family: 'Zapfino'; font - style: normal; font - weight: 400; src: url('/_ui/fonts/Zapfino/Zapfino.ttf'); }" +
                    "@font-face { font - family: 'OptimaLT'; font - style: normal; font - weight: 400; src: url('/_ui/fonts/OptimaLT/Optima-LT'); }" +
                    "@font-face { font - family: 'avenir_sb'; font - style: normal; font - weight: 600; src: url('/_ui/fonts/Avenir/Avenir-Medium-09.ttf'); } </style> " +
                    "</head><body>" +
                    "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='width: 600px;border: solid 2px #401660;background-color: #fafafa;margin: 0 auto;text-align: center;'>" +
                    "<tr><td>" +
                    "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-top: 56px;'>" +
                    " <tr> <td><img style='width: 201px; height: 95px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589879434972.png' alt='Trade Works' /></td></tr>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "<tr><td style='color: #000000;font-size: 16px;padding-top: 13px;font-family: avenir_black_r;text-transform: uppercase;padding: 20px 110px 5px 110px'>RObert Couturier INC is delighted to share their New Portfolio with you!</td></tr>" +
                    "<tr><td><table  border='0' cellpadding='0' cellspacing='0' width='83%' style='margin: 0 auto;'>" +
                    "<tr><td style='font-size: 15px;color: #000000;font-family: Helvetica;padding: 0 8px;font-style: oblique;'>Hey Lorne! It was great meeting you lat last nights AD conference. I am seding you a sample of my work. I am looking forward to work together. Robert Couturier</td></tr>" +
                    "<tr><td><table table border='0' cellpadding='0' cellspacing='0' width='80%' style='margin: 0 auto;margin-bottom: 30px;margin-top: 20px;'>" +
                    "<tr><td><a href='#' style='color: #410166;font-size: 12.4px;font-family: avenir_black_r; border-radius: 13.5px;border: solid 1px #410166;background-color: #ffffff;outline: none;text-decoration: none;padding: 4px 15px;'>VISIT ROBERT’S PORTFOLIO</a></td></tr>" +
                    "</table></td></tr></table></td></tr></table></td></tr>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='95%' style='margin: 0 auto; background-color: #ffffff;border: solid 1px #979797;'>" +
                    "<tr><td style='font-size: 24.2px;color: #000000;padding-top: 8px'>Robert Couturier Inc.</td></tr>" +
                    "<tr><td><img style = 'width: 18px; height: 41px' src = 'https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1603175110280.jpg'></td></tr>" +
                    "<tr><td><img style='width: 580px; height: 420px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1603179095138.PNG'> </td></tr>" +
                    "</table></td></tr>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "<tr><td><img style='padding-top: 23px;padding-bottom: 23px;width: 280px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1603180042430.png'></td></tr>" +
                    "</table></td></tr>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "<tr><td><img style='width: 580px; height: 420px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1603174874153.PNG'></td></tr>" +
                    "</table></td></tr></table></td></tr>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%' style='background-color: #fafafa;padding: 0 22px;'>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "<tr><td><img style='width: 60px;height: 60px;padding-top: 16px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589898533593.png'></td></tr>" +
                    "<tr><td style='font-size: 14.4px;font-family: avenir_bold;font-weight: 900;color: #000000;padding: 12px 0'>CHECK OUT THE LATEST COMPANY REVIEWS</td></tr>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-bottom: 30px'>" +
                    "<tr> <th></th> <th></th> <th></th></tr>" +
                    "<tr><td><img style='width: 154px;height: 98px;' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589895044763.png'></td>" +
                    "<td><img style='width: 154px;height: 98px;' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589897044357.png'></td>" +
                    "<td><img style='width: 154px;height: 98px;' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589897075041.png'></td></tr>" +
                    "<tr><td style='font-size: 12px;color: #000000;font-family:gillsans_r;padding-top: 7px;padding-bottom: 4px;'>Ageloff & Associates</td>" +
                    "<td style='font-size: 12px;color: #000000;font-family:gillsans_r;padding-top: 7px;padding-bottom: 4px;'>Robert Couturier</td>" +
                    "<td style='font-size: 12px;color: #000000;font-family:gillsans_r;padding-top: 7px;padding-bottom: 4px;'>Thomas Scheerer</td></tr>" +
                    "<tr><td style=''><img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' /></td>" +
                    "<td style=''><img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' /></td>" +
                    "<td style=''><img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "<img style='width: 18px;height: 17px' src='https://trablobdev.blob.core.windows.net/tra-con-use-dev/temp/1589881845263.png' />" +
                    "</td></tr></table></td></tr></table></td></tr></table></td></tr>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%' style='background-color: #ffffff'>" +
                    "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='60%' style='margin: 0 auto; background-color: #ffffff'>" +
                    "<tr><td style='font-size: 12px;color: #171717;font-family: avenir_light;padding-top: 25px'>If you have any questions, please contact Customer Service at 866.960.9100 or at editor@franklin.works</td></tr>" +
                    "<tr><td><a style='font-size: 12px;color: #979797;font-family: avenir_light;'href='#'>Unsubscribe</a></td></tr>" +
                    "<tr><td style='padding-top: 8px;color: #401660;font-size: 15px;font-family: gillsans_sb;padding-bottom: 6px'>The Franklin Report &reg;</td></tr>" +
                    "</table></td></tr></table></td></tr>" +
                    "</table>" +
                    "</body></html>";
            string numberFilePath = "~/app/test.html";
            var apiKey = "test";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("praneeth.pn@gmail.com", "Franklin Support"),
                Subject = "Test",
                PlainTextContent = "",
                HtmlContent = "Hi"
            };
            //byte[] bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/app/test.html"));
            //var file = Convert.ToBase64String(bytes);
            //msg.AddAttachment("ABC.pdf", file);
            msg.AddTo("rohita@menlo-technologies.com");
            var response = client.SendEmailAsync(msg);
            if (System.IO.File.Exists("~/app/test.html"))
            {
                try
                {
                    System.IO.File.Delete("~/app/test.html");
                }
                catch (Exception ex)
                {
                    //Do something
                }
            }
            using (StreamWriter writer = new StreamWriter("~/app/test.html"))
            {
                writer.WriteLine(body);
            }
            //_baseHelper.SendMail("Email Notification", "Hi", "register@iaminterviewed.com", "praneeth.pn@gmail.com", true);
            //_baseHelper.SendMailWithAttachment("Email Notification", "Hi", "register@iaminterviewed.com", "praneeth.pn@gmail.com", true);
        }
    }
}