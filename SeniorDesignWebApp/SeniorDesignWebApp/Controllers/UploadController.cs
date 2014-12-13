using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure; 

namespace SeniorDesignWebApp.Controllers
{
    public class UploadController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();
        static int NUM_STATUTES = 20;
        string[] STATUTES = new string[NUM_STATUTES];
        static int STATUTE_LENGTH = 10;
        static int NUM_OCG = 2;

        // GET: Upload
        public ActionResult Index()
        {
            var model = new SeniorDesignWebApp.Models.upload();
            return View(model);
        }
        /** Uploading File feature */
        [HttpPost]
        public ActionResult Index(SeniorDesignWebApp.Models.upload model)
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "/upload.csv";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            byte[] uploadedFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
            System.IO.File.WriteAllBytes(path, uploadedFile);

            // now you could pass the byte array to your model and store wherever 
            // you intended to store it

            int level = 0;
            DataTableReader dtr = ConstructDataTableReader(path);
            casetable cas = new casetable();
            string prev_num = "";
            while (dtr.Read())
            {
                bool new_case;

                if (level == 1)
                {
                    index = 31;

                    for (int x = 0; x < NUM_STATUTES; x++)
                    {
                        STATUTES[x] = dtr.GetString(index);
                        index = index + STATUTE_LENGTH;
                    }
                }
                else if (level > 2)
                {

                    int index = 0;
                    string first = dtr.GetString(index++);
                    if (first.Equals(""))
                    {
                        break;
                    }
                    else if (!first.Split('.')[0].Equals(prev_num))
                    {
                        cas = new casetable();
                        new_case = true;
                        prev_num = first.Split('.')[0];
                    }
                    else
                    {
                        new_case = false;
                    }
                    index++;

                    // creating new objects to insert
                    arrestchargedetail acd = new arrestchargedetail();
                    bail bail = new bail();
                    defendant def = new defendant();
                    judge jud = new judge();
                    sentence sen = new sentence();
                    victim vic = new victim();

                    // assigning objects variables use method
                    // dtr.getTYPE( index++ ); where TYPE refers to the type of the variable to fetch
                    // index++ because we use several loops to eliminate the recurrence of columns throughout the document
                    // also, using index++ in each of these accesses allows us to cut-and-paste these statements elsewhere if the
                    // document structure ever changes in the future. Which, in my humble opinion, will

                    def.Lastname = dtr.GetString(index++);
                    def.Firstname = dtr.GetString(index++);
                    index++;

                    cas.Name = dtr.GetString(index++);
                    cas.Number = dtr.GetString(index++);
                    cas.Num_Defendants = Convert.ToInt32(dtr.GetString(index++));
                    cas.State = dtr.GetString(index++);
                    cas.FederalDistrict = Convert.ToInt32(dtr.GetString(index++));

                    jud.Name = dtr.GetString(index++);
                    jud.Race = Convert.ToInt32(dtr.GetString(index++));
                    jud.Gender = (dtr.GetString(index++) == "M" ? false : true);
                    jud.Tenure = Convert.ToInt32(dtr.GetString(index++));
                    jud.AppointedBy = Convert.ToInt32(dtr.GetString(index++));

                    // cas.Summary = dtr.GetString(index++); // case doesn't have Summary column :o woops
                    index++;

                    def.Gender = (dtr.GetString(index++) == "M" ? false : true);
                    def.Race = Convert.ToInt32(dtr.GetString(index++));
                    def.BirthDate = Convert.ToInt32(dtr.GetString(index++));

                    //skipping over arrestage column
                    index++;

                    acd.ChargeDate = Convert.ToDateTime(dtr.GetString(index++));
                    acd.ArrestDate = Convert.ToDateTime(dtr.GetString(index++));
                    acd.Detained = (dtr.GetString(index++) == "0") ? false : true;

                    bail.Type = Convert.ToInt32(dtr.GetString(index++));
                    if (bail.Type != 0)
                    {
                        bail.Amount = Convert.ToDouble(dtr.GetString(index++));
                        acd.bails.Add(bail);
                    }
                    else
                    {
                        index++;
                    }

                    acd.LaborTraf = (dtr.GetString(index++) == "0") ? false : true;
                    acd.AdultSexTraf = (dtr.GetString(index++) == "0") ? false : true;
                    acd.MinorSexTraf = (dtr.GetString(index++) == "0") ? false : true;
                    acd.Role = (dtr.GetString(index++) == "0") ? false : true;
                    acd.Fel_C = Convert.ToInt32(dtr.GetString(index++));
                    acd.Fel_S = Convert.ToInt32(dtr.GetString(index++));

                    // This loop increments over all of the statues in this document
                    for (int x = 0; x < NUM_STATUTES; x++)
                    {
                        // if the statute is being charged
                        if (dtr.GetString(index++) == "1")
                        {
                            // will replace -1 later
                            charge c = new charge();
                            c.Counts = Convert.ToInt32(dtr.GetString(index++));
                            c.CountsNolelProssed = Convert.ToInt32(dtr.GetString(index++));
                            c.PleaDismissed = Convert.ToInt32(dtr.GetString(index++));
                            c.PleaGuilty = Convert.ToInt32(dtr.GetString(index++));
                            c.TrialGuilty = Convert.ToInt32(dtr.GetString(index++));
                            c.TrialNotGuilty = Convert.ToInt32(dtr.GetString(index++));
                            c.Fines = Convert.ToInt32(dtr.GetString(index++));
                            c.Sentence = Convert.ToInt32(dtr.GetString(index++));
                            c.Probation = Convert.ToInt32(dtr.GetString(index++));
                            c.Statute = "Statute";

                            acd.charges.Add(c);
                        }
                        else
                        {
                            index = index + STATUTE_LENGTH - 1;
                        }
                    }

                    sen.DateTerminated = Convert.ToDateTime(dtr.GetString(index++));
                    sen.Date = Convert.ToDateTime(dtr.GetString(index++));
                    sen.Total = Convert.ToInt32(dtr.GetString(index++));
                    sen.Restitution = Convert.ToDouble(dtr.GetString(index++));
                    sen.AssetForfeit = (dtr.GetString(index++) == "0") ? false : true;
                    sen.Appeal = (dtr.GetString(index++) == "0") ? false : true;
                    sen.SupervisedRelease = Convert.ToInt32(dtr.GetString(index++));
                    sen.Probation = Convert.ToInt32(dtr.GetString(index++));

                    vic.Total = Convert.ToInt32(dtr.GetString(index++));
                    vic.Minor = Convert.ToInt32(dtr.GetString(index++));
                    vic.Foreigner = Convert.ToInt32(dtr.GetString(index++));
                    vic.Female = Convert.ToInt32(dtr.GetString(index++));

                    //  this loop increments over all of the ocgs in this document
                    for (int x = 0; x < NUM_OCG; x++)
                    {
                        string temp_name = dtr.GetString(index++);
                        int temp_type = Convert.ToInt32(dtr.GetString(index++));
                        if (temp_type != 0)
                        {
                            organizedcrimegroup ocg = new organizedcrimegroup();
                            ocg.Name = temp_name;
                            ocg.Size = temp_type;
                            ocg.Race = Convert.ToInt32(dtr.GetString(index++));
                            ocg.Scope = Convert.ToInt32(dtr.GetString(index++));
                            cas.organizedcrimegroups.Add(ocg);
                        }
                    }

                    acd.casetables.Add(cas);
                    db.arrestchargedetails.Add(acd);
                    
                    if (bail.Type != 0)
                    {
                        bail.arrestchargedetail = acd;
                        db.bails.Add(bail);
                    }

                    cas.arrestchargedetail = acd;
                    cas.defendants.Add(def);
                    cas.judges.Add(jud);
                    if (new_case)
                    {
                        db.casetables.Add(cas);
                    }

                    foreach (charge c in acd.charges)
                    {
                        db.charges.Add(c);
                    }

                    def.casetables.Add(cas);
                    db.defendants.Add(def);

                    jud.casetables.Add(cas);
                    db.judges.Add(jud);

                    foreach (organizedcrimegroup ocg in cas.organizedcrimegroups)
                    {
                        ocg.casetables.Add(cas);
                        db.organizedcrimegroups.Add(ocg);
                    }

                    sen.casetables.Add(cas);
                    db.sentences.Add(sen);

                    vic.casetables.Add(cas);
                    db.victims.Add(vic);
                }

                // incrementing level (ROW_NUMBER)
                level++;
            }
            

            db.SaveChanges();

            return Content("DONE");
        }

        protected DataTableReader ConstructDataTableReader(string pathname)
        {
            DataTable dt = new DataTable();
            bool isFirstRowHeader = true;
            string[] colf = new string[] { "" };
            using (TextFieldParser parser = new TextFieldParser(pathname))
            {
                parser.TrimWhiteSpace = true;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                if (isFirstRowHeader)
                {
                    colf = parser.ReadFields();
                    foreach (string sds in colf)
                    {
                        DataColumn col = new DataColumn(sds.Trim().ToLower(), Type.GetType("System.String"));
                        dt.Columns.Add(col);
                    }
                }
                while (true)
                {
                    if (!isFirstRowHeader)
                    {
                        string[] parts = parser.ReadFields();
                        if (parts == null)
                        {
                            break;
                        }
                        System.Diagnostics.Debug.Write(parts);
                        dt.Rows.Add(parts);
                    }
                    isFirstRowHeader = false;
                }
            }
            return new DataTableReader(dt);
        }

        public int index { get; set; }
    }
}