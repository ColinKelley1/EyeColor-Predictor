//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:        Project3Part1
//	File Name:		Part1.cs
//	Description:    Find the most likely eye color from a gene file.
//	Course:			CSCI 3230-001 - Algorithms
//	Author:			Colin Kelley
//	Created:	    3/20/2018
//	Copyright:		Colin Kelley, 2019
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project3Part1
{
    class Part1
    {

        /// <summary>
        /// Struct object is an rsid. Properties are the id and its two allele's
        /// </summary>
        struct RSID
        {
            public string id;
            public char allele1;
            public char allele2;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  This method of finding eye color is based of of the figure table at this link: https://www.ncbi.nlm.nih.gov/pmc/articles/PMC3694299/figure/F2/
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Main method 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string instring;
            string[] values = new string[5];

            int skipCnt = 0;        //Counter to skip first 16 lines(header)
   
            string rsid;

            RSID[] rsids = new RSID[5];

            //Initialize the properties
            rsids[0].id = "rs12913832";
            rsids[1].id = "rs16891982";
            rsids[2].id = "rs6119471";
            rsids[3].id = "rs12203592";
            rsids[4].id = "rs12896399";           

            //Fill in 0's for the alleles
            for (int i = 0; i < 5; i++)
            {
                rsids[i].allele1 = '0';
                rsids[i].allele2 = '0';
            }



            string eyeColor = "";

            //Holds the allele that we are working with
            char allele1;
            char allele2;

            instring = Console.ReadLine();          //Read the first line in from DNA file

            //Reads in line and sees if its relative to eye color
            while (instring != null)
            {
                //Skips the header of the file
                if (skipCnt <=16)
                {
                    skipCnt++;
                    instring = Console.ReadLine();          //Read the first line in from DNA file
                    continue;
                }


                values = instring.Split('\t');          //split values tab delimited

                rsid = values[0];
                allele1 = char.Parse(values[3]);        //Store allele1
                allele2 = char.Parse(values[4]);        //Store allele2

                //See if rsid matches any of the numbers
                for(int i = 0; i < 5;i++)
                {
                    //If the rsid is one that matters then store its allele's
                    if (rsid == rsids[i].id)
                    {
                        rsids[i].allele1 = allele1;     //Store
                        rsids[i].allele2 = allele2;     //Store
                    }
                }



                instring = Console.ReadLine();          //Read the first line in from DNA file
            }

            //See if rsid matches any of the numbers
            for (int i = 0; i < 5; i++)
            {
                if(rsids[i].allele1 != '0')

                Console.WriteLine("RSID found: " + rsids[i].id + " Alleles: " + rsids[i].allele1 + " " + rsids[i].allele2);   //Print RSIDs
            }

            //If it is AG then the eye color is 100% brown
            if((rsids[0].allele1 == 'A' && rsids[0].allele2 == 'G') || (rsids[0].allele1 == 'G' && rsids[0].allele2 == 'A'))
            {
                eyeColor = "Most likely brown. Not blue.";
            }
            
            //If AA then it is not blue
            else if(rsids[0].allele1 == 'A' && rsids[0].allele2 == 'A')
            {
                //If CC then it can be green or brown
                if (rsids[2].allele1 == 'C' && rsids[2].allele2 == 'C')
                {
                    //Check for possible rsids
                    if (rsids[4].allele1 == 'T' && rsids[4].allele2 == 'T')
                    {
                        eyeColor = "Most likely green. Not blue.";
                    }
                    if (rsids[3].allele1 == 'G' && rsids[3].allele2 == 'G')
                    {
                        eyeColor = "Most likely brown. Not blue.";
                    }                   
                }
                //If others fail then check this rsid
                else if (rsids[1].allele1 == 'G' && rsids[1].allele2 == 'G')
                {
                    eyeColor = "Most likely brown. Not blue.";
                }
                //If its not that one then it is 80% brown
                else
                {
                    eyeColor = "80% possibility of brown and 20% possibility of green.";
                }

            }

            //This means not Brown
            else if(rsids[0].allele1 == 'G' && rsids[0].allele2 == 'G')
            {
                //Check for possible rsids (blue or green)
                if (rsids[4].allele1 == 'T' && rsids[4].allele2 == 'T')
                {
                    if(rsids[2].allele1 == 'C' && rsids[2].allele1 == 'C')
                    {
                        eyeColor = "Most likely green. Not brown.";
                    }                   
                    else
                    {
                        eyeColor = "Most likely blue. Not brown.";
                    }
                }
                else if(rsids[1].allele1 == 'T' && rsids[1].allele2 == 'T')
                {
                    eyeColor = "Most likely blue. Not brown.";
                }
                else
                {
                    eyeColor = "Most likely Green. Not brown";
                }
            }
            
            //Display the final result
            Console.WriteLine();
            Console.WriteLine("The eye color is: " + eyeColor);
           

        }
    }
}
