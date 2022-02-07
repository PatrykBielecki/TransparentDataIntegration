using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransparentData.Connections.Webcon;
using TransparentData.Models.TransparentData;
using TransparentData.Models.Webcon;
using TransparentData.Service;

namespace TransparentData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransparentdataController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly ITdService _service;
        private readonly IWebconConnection _webcon;

        public TransparentdataController(ILogger<TransparentdataController> logger, ITdService service, IWebconConnection webcon)
        {
            _logger = logger;
            _service = service;
            _webcon = webcon;
        }

        [HttpGet("hc")]
        public string HC()
        {
            return ":)";
        }

        [HttpGet("KRS")]
        public IActionResult GetKRS(int elementID) //5213668813
        {
            _logger.LogInformation("Start get KRS");

            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;

            var res = _service.GetJson("krs", new Models.Params() { Nip = nip });

            if (res == "TDTIMEOUT") { SendTDTIMEOUT(elementID, "KRS"); return Ok(); };

            var result = JObject.Parse(res);


            if (result.Last.ToString().Contains("error_message"))
            {
                var errElement = new Element()
                {
                    Comments = new Comments()
                    {
                        NewComment = "Brak wpisu KRS dla danego numeru nip"
                    }
                };

                _webcon.PatchElement(elementID, errElement);

                _logger.LogInformation("Brak wpisu KRS dla danego numeru nip");

                return Ok();
            }

            KrsResult krsResult = result.ToObject<KrsElement>().Result;

            var element = new Element()
            {
                FormFields = new List<Models.Webcon.FormField>()
                {
                    new Models.Webcon.FormField()
                    {
                        Guid = "ad2398e6-b310-421d-b768-1c072d81549b",
                        Svalue = krsResult.Name,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "db24f926-78b8-46e5-8c0c-8c67e2f50f37",
                        Svalue = krsResult.LegalForm,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "956ebf0b-0b33-4e4f-9a0c-307790f66b8c",
                        Svalue = krsResult.Krs,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "44fa0ec5-9301-428e-8b47-96ab703f5212",
                        Svalue = krsResult.Nip,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "ed42eec5-b5fb-4d1d-93a5-007e0a1a9db3",
                        Svalue = krsResult.Regon,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "2a8c0d54-5e82-4d8f-b71c-3bc3d930858d",
                        Svalue = krsResult.CompanyStatus,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "0a038e55-0032-433b-8e97-1e17804b24e5",
                        Svalue = krsResult.Address.Street,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "6b754009-3550-4d7d-86c7-6bf19bdf2dde",
                        Svalue = krsResult.Address.Postcode,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "fe49cc07-c528-4bd6-b2bc-0f89e0a38456",
                        Svalue = krsResult.Address.City,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "70b57504-0bae-4832-a8a4-4a0bdc90d836",
                        Svalue = krsResult.Incorporation,
                        Type = "SingleLine"
                    }
                }
            };
            _webcon.PatchElement(elementID, element);
            _logger.LogInformation("Stop get KRS");

            return Ok();
        }

        [HttpGet("CEIDG")]
        public IActionResult GetCEIDG(int elementID) //8751451718
        {
            _logger.LogInformation("Start get CEIDG");

            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;

            var res = _service.GetJson("ceidg", new Models.Params() { Nip = nip });

            if (res == "TDTIMEOUT") { SendTDTIMEOUT(elementID, "CEIDG"); return Ok(); };

            var result = JObject.Parse(res);

            if (result.Last.ToString().Contains("error_message"))
            {
                var errElement = new Element()
                {
                    Comments = new Comments()
                    {
                        NewComment = "Brak wpisu CEIDG dla danego numeru nip"
                    }
                };

                _webcon.PatchElement(elementID, errElement);

                _logger.LogInformation("Brak wpisu CEIDG dla danego numeru nip");

                return Ok();
            }

            CeidigResult ceidigResult = result.ToObject<CeidigElement>().CeidigResult;

            var element = new Models.Webcon.Element()
            {
                FormFields = new List<Models.Webcon.FormField>()
                {
                    new Models.Webcon.FormField()
                    {
                        Guid = "b8d9e6c5-ccea-4677-a0aa-5b2abe430c9c",
                        Svalue = ceidigResult.CompanyName,
                        Type = "SingleLine"
                    },
                        new Models.Webcon.FormField()
                    {
                        Guid = "50d7dff6-ce18-4631-8dcf-d027d3a579bd",
                        Svalue = ceidigResult.Nip,
                        Type = "SingleLine"
                    },
                        new Models.Webcon.FormField()
                    {
                        Guid = "a2626c49-867b-45ca-acfe-0313e4d29646",
                        Svalue = ceidigResult.Regon,
                        Type = "SingleLine"
                    },
                        new Models.Webcon.FormField()
                    {
                        Guid = "7774fdf6-d604-4dc6-bea5-a0b6cf745dd6",
                        Svalue = ceidigResult.CompanyStatus,
                        Type = "SingleLine"
                    },
                        new Models.Webcon.FormField()
                    {
                        Guid = "a9bf2dee-558a-4a05-8409-90a68ba7b0e3",
                        Svalue = ceidigResult.BeginningDate.ToString(),
                        Type = "SingleLine"
                    },
                        new Models.Webcon.FormField()
                    {
                        Guid = "c9e08fd5-585e-43a3-9f4a-8608f786163f",
                        Svalue = ceidigResult.MainAddress.Street,
                        Type = "SingleLine"
                    },
                        new Models.Webcon.FormField()
                    {
                        Guid = "bb869201-cd8d-47a1-abd4-420379cfe1f0",
                        Svalue = ceidigResult.MainAddress.City,
                        Type = "SingleLine"
                    },
                        new Models.Webcon.FormField()
                    {
                        Guid = "301c2e67-358d-4a16-9120-fa7f0f6a3b7f",
                        Svalue = ceidigResult.MainAddress.Postcode,
                        Type = "SingleLine"
                    }
                }
            };
            _webcon.PatchElement(elementID, element);

            _logger.LogInformation("Stop get CEIDG");
            return Ok();
        }

        [HttpGet("SanctionLists")]
        public IActionResult GetSanctionLists(int elementID, string name)
        {
            _logger.LogInformation("Start get SanctionLists");
            var result = JObject.Parse(_service.GetOther("aml_sanction", "check", new Models.Params() { Name = name }));

            PepResult pepResult = result.ToObject<PepElement>().PepResult;

            var element = new Models.Webcon.Element()
            {
                ItemLists = new List<Models.Webcon.ItemList>()
                {
                    new Models.Webcon.ItemList()
                    {
                        Guid = "0d86d026-feda-4024-acf1-f416a0bb2114",
                        Rows = new List<Models.Webcon.Row>()
                        {
                            new Models.Webcon.Row()
                            {
                                Cells = new List<Models.Webcon.Cell>()
                                {
                                    new Models.Webcon.Cell()
                                    {
                                        Svalue = name,
                                        Guid = "24af66d0-c60c-47d8-99ca-3630181ab093"
                                    },
                                    new Models.Webcon.Cell()
                                    {
                                        Svalue = pepResult.ListDetails,
                                        Guid = "f1c692e8-892e-4d75-8fd1-a52b68aa5e41"
                                    }
                                }
                            }
                        }
                    }
                }
            };
            _webcon.PatchElement(elementID, element);

            _logger.LogInformation("Stop get SanctionLists");
            return Ok(result);
        }

        [HttpGet("Beneficiary")]
        public IActionResult GetBeneficiary(int elementID)
        {
            _logger.LogInformation("Start get Beneficiary");

            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;

            var res = _service.GetOther("beneficiary", "getPl", new Models.Params() { Nip = nip });

            if (res == "TDTIMEOUT") { SendTDTIMEOUT(elementID, "KRS"); return Ok(); };

            var result = JObject.Parse(res);

            if (result.Last.ToString().Contains("error_message"))
            {
                var errElement = new Element()
                {
                    Comments = new Comments()
                    {
                        NewComment = "Brak beneficjentów dla danego numeru nip"
                    }
                };

                _webcon.PatchElement(elementID, errElement);

                _logger.LogInformation("Brak beneficjentów dla danego numeru nip");

                return Ok();
            }

            BeneficaryResult beneficaryResult = result.ToObject<BeneficaryElement>().BeneficaryResult;

            var lista = new List<Models.Webcon.Cell>() { };

            if (beneficaryResult is null) return Ok();

            for (int i = 0; i < beneficaryResult.Beneficiaries.Count; i++)
            {
                _ = GetPEP(elementID, beneficaryResult.Beneficiaries[i].Name);
                _ = GetSanctionLists(elementID, beneficaryResult.Beneficiaries[i].Name);

                var element = new Models.Webcon.Element()
                {
                    ItemLists = new List<Models.Webcon.ItemList>()
                {
                    new Models.Webcon.ItemList()
                    {
                        Guid = "c94758af-2e57-44c6-8070-28e9d59dbc26",
                        Rows = new List<Models.Webcon.Row>()
                        {
                            new Models.Webcon.Row()
                            {
                                Cells = new List<Models.Webcon.Cell>()
                                {
                                    new Models.Webcon.Cell()
                                    {
                                        Svalue = beneficaryResult.Beneficiaries[i].Pesel,
                                        Guid = "7412c100-5f8a-4a73-b833-912ac4552cda"
                                    },
                                    new Models.Webcon.Cell()
                                    {
                                        Svalue = beneficaryResult.Beneficiaries[i].Name,
                                        Guid = "b621f44e-deca-477a-8e11-7836be1caae5"
                                    }
                                }
                            }
                        }
                    }
                }
                };
                _webcon.PatchElement(elementID, element);
            }

            _logger.LogInformation("Stop get Beneficiary");


            return Ok(result);
        }

        [HttpGet("PEP")]
        public IActionResult GetPEP(int elementID, string name)
        {
            _logger.LogInformation("Start get PEP");
            var result = JObject.Parse(_service.GetOther("pep", "check", new Models.Params() { Name = name }));

            PepResult pepResult = result.ToObject<PepElement>().PepResult;

            var element = new Models.Webcon.Element()
            {
                ItemLists = new List<Models.Webcon.ItemList>()
                {
                    new Models.Webcon.ItemList()
                    {
                        Guid = "a07f5693-7918-41aa-99b0-097e88cb0756",
                        Rows = new List<Models.Webcon.Row>()
                        {
                            new Models.Webcon.Row()
                            {
                                Cells = new List<Models.Webcon.Cell>()
                                {
                                    new Models.Webcon.Cell()
                                    {
                                        Svalue = name,
                                        Guid = "832db445-6225-40f9-860f-ba966c7a35fd"
                                    },
                                    new Models.Webcon.Cell()
                                    {
                                        Svalue = pepResult.ListDetails,
                                        Guid = "aa64ae16-f3d1-432f-a92c-1a26dcf283ab"
                                    }
                                }
                            }
                        }
                    }
                }
            };
            _webcon.PatchElement(elementID, element);

            _logger.LogInformation("Stop get PEP");
            return Ok(result);
        }

        [HttpGet("WhiteList")]
        public IActionResult GetWhiteList(int elementID)
        {
            _logger.LogInformation("Start get WhiteList");

            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;

            var res = _service.GetOther("white_list", "getWhiteList", new Models.Params() { Nip = nip, AdditionalInfo = true });

            if (res == null) { SendTDTIMEOUT(elementID, "Biała lista"); return Ok(); };

            var result = JObject.Parse(res);

            if (result.Last.ToString().Contains("error_message"))
            {
                var errElement = new Element()
                {
                    Comments = new Comments()
                    {
                        NewComment = "Brak whitelist dla danego numeru nip"
                    }
                };

                _webcon.PatchElement(elementID, errElement);

                _logger.LogInformation("Brak whitelist dla danego numeru nip");

                return Ok();
            }

            WhitelistResult whitelistResult = result.ToObject<WhitelistElement>().WhitelistResult;

            if (whitelistResult.VatStatus == "Nie figuruje w rejestrze VAT")
            {
                var errElement = new Element()
                {
                    Comments = new Comments()
                    {
                        NewComment = "Brak whitelist - Nie figuruje w rejestrze VAT"
                    }
                };

                _webcon.PatchElement(elementID, errElement);

                _logger.LogInformation("Brak whitelist - Nie figuruje w rejestrze VAT");

                return Ok();
            }



            var element = new Models.Webcon.Element()
            {
                FormFields = new List<Models.Webcon.FormField>()
                {

                    new Models.Webcon.FormField()
                    {
                        Guid = "a5576d2f-475b-4115-a263-e53031e2dcd9",
                        Svalue = whitelistResult.Name,
                        Type = "SingleLine"
                    },

                     new Models.Webcon.FormField()
                    {
                        Guid = "660c4ac3-1149-45f6-b304-5a8a9bc4e072",
                        Svalue = whitelistResult.Nip,
                        Type = "SingleLine"
                    },
                     new Models.Webcon.FormField()
                    {
                        Guid = "668be9d5-a5e9-47e6-8697-a68eb3d24ee8",
                        Svalue = whitelistResult.VatStatus,
                        Type = "SingleLine"
                    },

                     new Models.Webcon.FormField()
                    {
                        Guid = "60ed40ca-0b86-473b-91d1-f1b8bd797a6e",
                        Svalue = whitelistResult.Regon,
                        Type = "SingleLine"
                    },

                     new Models.Webcon.FormField()
                    {
                        Guid = "141af067-9995-40af-a77c-a253554638c0",
                        Svalue = whitelistResult.Krs,
                        Type = "SingleLine"
                    },

                     new Models.Webcon.FormField()
                    {
                        Guid = "c5594a1c-c27a-490f-a466-019a0fb9bbca",
                        Svalue = whitelistResult.WhitelistRevenueAgency.Name,
                        Type = "SingleLine"
                    }
                }
            };
            _webcon.PatchElement(elementID, element);

            _logger.LogInformation("Stop get WhiteList");

            return Ok(result);
        }

        [HttpGet("RiskRaportPDF")]
        public IActionResult GetRiskRaportPDF(int elementID)
        {
            _logger.LogInformation("Start get RiskRaportPDF");

            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;

            var result = _service.GetFile("raport_ryzyka", "pdf", new Models.Params() { Nip = nip });

            if (result == null) { SendTDTIMEOUT(elementID, "Raport ryzyka PDF"); return Ok(); };

            if (result == "") { SendNODATA(elementID, "Raport ryzyka PDF"); return Ok(); };

            var element = new Attachment()
            {
                AttachmentName = "raport_ryzyka.pdf",
                AttachmentContent = result,
                AttachmentGroup = "1#Raport Oceny Ryzyka"
            };

            _ = _webcon.PostAttachment(elementID, element);

            _logger.LogInformation("Stop get RiskRaportPDF");
            return Ok();
        }

        [HttpGet("RaportPrzeswietlPDF")]
        public IActionResult GetRaportPrzeswietlPDF(int elementID)
        {
            _logger.LogInformation("Start get PrzeswietlPDF");

            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;

            var result = _service.GetFile("raport_przeswietl", "pdf", new Models.Params() { Nip = nip });

            if (result == null) { SendTDTIMEOUT(elementID, "Przeswietl PDF"); return Ok(); };

            if (result == "") { SendNODATA(elementID, "Przeswietl PDF"); return Ok(); };

            var element = new Attachment()
            {
                AttachmentName = "raport_przeswietl.pdf",
                AttachmentContent = result,
                AttachmentGroup = "2#Raport Przewietl"
            };

            _ = _webcon.PostAttachment(elementID, element);

            _logger.LogInformation("Stop get PrzeswietlPDF");
            return Ok();
        }

        [HttpGet("WhitelistPDF")]
        public IActionResult GetWhitelistPDF(int elementID)
        {
            _logger.LogInformation("Start get WhitelistPDF");

            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;

            var result = _service.GetFile("white_list", "pdf", new Models.Params() { Nip = nip });

            if (result == null) { SendTDTIMEOUT(elementID, "Biała lista PDF"); return Ok(); };

            if (result == "") { SendNODATA(elementID, "Biała lista PDF"); return Ok(); };

            var element = new Attachment()
            {
                AttachmentName = "biala_lista.pdf",
                AttachmentContent = result,
                AttachmentGroup = "3#Raport Biala Lista"
            };

            _ = _webcon.PostAttachment(elementID, element);

            _logger.LogInformation("Stop get WhitelistPDF");
            return Ok();
        }

        [HttpGet("DownloadAll")]
        public IActionResult DownloadAll(int elementID)
        {
            Element webconElement = _webcon.GetElement(elementID);
            int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
            string nip = webconElement.FormFields[x].Svalue;
            new Task(() => { RunAll(elementID); }).Start();

            return Ok();
        }

        private void RunAll(int elementID)
        {
            new Task(() => { GetBeneficiary(elementID); }).Start();
            new Task(() => { GetWhiteList(elementID); }).Start();
            new Task(() => { GetRiskRaportPDF(elementID); }).Start();
            new Task(() => { GetRaportPrzeswietlPDF(elementID); }).Start();
            new Task(() => { GetWhitelistPDF(elementID); }).Start();
            new Task(() => { GetKRS(elementID); }).Start();
            new Task(() => { GetCEIDG(elementID); }).Start();
        }

        private void SendTDTIMEOUT(int elementID, string elementName)
        {
            var errElement = new Element()
            {
                Comments = new Comments()
                {
                    NewComment = "Nie pobrano " + elementName + ", brak odpowiedzi od Transparent Data"
                }
            };

            _webcon.PatchElement(elementID, errElement);
            _logger.LogInformation("Nie pobrano " + elementName + ", brak odpowiedzi od Transparent Data");
        }

        private void SendNODATA(int elementID, string elementName)
        {
            var errElement = new Element()
            {
                Comments = new Comments()
                {
                    NewComment = "Nie znaleziono w bazie " + elementName + " dla podanego numeru nip"
                }
            };

            _webcon.PatchElement(elementID, errElement);
            _logger.LogInformation("Nie znaleziono w bazie " + elementName + " dla podanego numeru nip");
        }

        //[HttpGet("Financial")]
        //public IActionResult GetFinancialZip(int elementID)
        //{
        //    _logger.LogInformation("Start get Financial");

        //    Element webconElement = _webcon.GetElement(elementID);
        //    int x = webconElement.FormFields.FindIndex(x => x.Guid == "45f164b6-9186-47c3-99b3-aa2d792f0be6");
        //    string nip = webconElement.FormFields[x].Svalue;

        //    var result = _service.GetFile("financial_ranges", "zip", new Models.Params()
        //    {
        //        Nip = nip,
        //        DatesRanges = new List<string> { $"2021-01-01|2021-01-31" }
        //    });

        // if (result == "NODATA")
        // {
        //   var errElement = new Element()
        //   {
        //       Comments = new Comments()
        //       {
        //           NewComment = "Brak sprawozdania finansowego ZIP dla danego numeru nip"
        //       }
        //   };

        //   _webcon.PatchElement(elementID, errElement);

        //   _logger.LogInformation("Brak sprawozdania finansowego ZIP dla danego numeru nip");

        //   return Ok();
        //}

        //    var element = new Attachment()
        //    {
        //        AttachmentName = "sprawozdanie_finansowe.zip",
        //        AttachmentContent = result,
        //        AttachmentGroup = "4#Sprawozdanie finansowe"
        //    };

        //    _ = _webcon.PostAttachment(elementID, element);

        //    _logger.LogInformation("Stop get Financial");
        //    return Ok(result);
        //}


    }
}
