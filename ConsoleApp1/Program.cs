// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;

namespace HtmlTag
{
    class program
    {
        static void Main(String[] args)
        {
            string userDesicion = "1";

            Console.WriteLine("Please type  1 to read HTML from code set as default" +
                "  or type 2 to read html from console");

            Console.WriteLine();

          //  string htmlText = "<div></tr><tr><tr> Hello world<div><tr></tr><div></div>";;
            string htmlText = @"
                            <div>hellow Bitfountain<div>
                        	<h1>This is <b>bold</b> heading<h1>
                        	<p>This is <u>underlined</u> paragraph</p>
                        	<h2>This is <i>italic</i> heading</h2>
                        ";
            
            userDesicion = Console.ReadLine();

            if(userDesicion == "1")
            {
                Console.WriteLine();
                Console.WriteLine("User deside to take HTML from code as default  ");
                Console.WriteLine();
            }
            if (userDesicion == "2")
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("User deside to take HTML from console ");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Please Write HTML To check");
                Console.WriteLine();
                htmlText = Console.ReadLine();
            }

              var htmlDoc = new HtmlDocument();
              htmlDoc.LoadHtml(htmlText);
              var parseErrors = htmlDoc.ParseErrors;


         //this code use for load file from computer as a file path

         // var doc = new HtmlDocument();
         // doc.Load(@"C:\Users\sk.nurulislam\Desktop\html_text.txt");
         //doc.Load(@"C:\Users\sk.nurulislam\Desktop\html_text.txt");
         // var parseErrors = doc.ParseErrors;

         //   if (doc.ParseErrors.Count() == 0)
         //   {
         //       Console.WriteLine("Correctly tagged paragraph");
         //   }



            if (htmlDoc.ParseErrors.Count() == 0 ) {
                Console.WriteLine();
                Console.WriteLine("Correctly tagged paragraph");
             }



            if (parseErrors != null)
            {
                int count = 0;
                foreach (var htmlParseError in parseErrors)
                {
                    count++;
                    Console.WriteLine();
                    Console.WriteLine("Tag issue - " + count);

                    if (htmlParseError.Code == HtmlParseErrorCode.TagNotOpened)
                    {
                        Console.WriteLine("Expected " + htmlParseError.Reason + ", Found tag  " + htmlParseError.SourceText);
                    }

                    if (htmlParseError.Code == HtmlParseErrorCode.TagNotClosed)
                    {
                                 Console.WriteLine("Expected  " + htmlParseError.Reason);

                    }

                    Console.WriteLine("Tag not found in line  "+ htmlParseError.Line + "  and position " + htmlParseError.LinePosition);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
           


        }
    }
}

