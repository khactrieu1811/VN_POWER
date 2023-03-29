using AutoMapper;
using Business.IRepostitory;
using Entities.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.APIs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Website.Services;

namespace Website.Api
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactRepository _contactRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        private readonly CaptchaVerificationService _captchaVerificationService;
        public ContactsController(ILogger<ContactsController> logger, IMapper mapper
            , IContactRepository contactRepository,
            IEmailRepository emailRepository,
            CaptchaVerificationService captchaVerificationService)
        {
            _logger = logger;
            _mapper = mapper;
            _contactRepository = contactRepository;
            _emailRepository = emailRepository;
            _captchaVerificationService = captchaVerificationService;
        }

        /// <summary>
        /// Contact Api
        /// </summary>
        /// <param name="registerFor">value: Home or Event or Scholarship</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Register/{registerFor}")]
        public IActionResult Register(string registerFor, ContactRequest model)
        {
            var result = new ResponseModel<int>()
            {
                Success = false,
               // Message = language.ToUpper() == "EN" ? "Bad Request":"Yêu cầu không hợp lệ"

            };
            try
            {
                if (model != null)
                {
                    var entity = new Contact()
                    {
                        Content = model.Message,
                        CreateDate = DateTime.Now,
                        FullName = model.FullName,
                        Phone = model.PhoneNumber,
                        Email = model.Email,
                        RegisterFor = registerFor,
                        Slug = model.Slug
                    };
                   
                    _contactRepository.Add(entity);
                    
                    string body = string.Empty;
                    //using streamreader for reading my htmltemplate   
                    using (StreamReader reader = new StreamReader(Path.Combine("wwwroot","Templetes", "EmailConfirmation.html")))
                    {
                        body = reader.ReadToEnd();
                    }

                    var email = new Email()
                    {
                        Id = Guid.NewGuid(),
                        EmailTo = model.Email,
                        DateCreated = DateTime.Now,
                        NameTo = model.FullName,
                        Subject = $"Your enquiry to TNR Services",
                        Body = body.Replace("[name]", model.FullName)
                    };

                    _emailRepository.Add(email);
                    result.Success = true;

                   // result.Message = language.ToUpper() == "EN" ? "Registered successfully" : "Đăng ký thành công";
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Contact Api
        /// </summary>
        /// <param name="registerFor">value: Home or Event or Scholarship</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterWithCapcha/{registerFor}")]
        public async Task<IActionResult> RegisterWithCapcha(string registerFor, ContactRequest model)
        {
            var result = new ResponseModel<int>()
            {
                Success = false,
            };
            var headers = Request.Headers;
           
            if (headers.ContainsKey("capchaToken"))
            {
                Request.Headers.TryGetValue("capchaToken", out var token);
                var validateToken = await _captchaVerificationService.IsCaptchaValid(token);
                if (!validateToken)
                {
                    result.Message = "Failed to process captcha validation";
                    return BadRequest(result);
                }
                try
                {
                    if (model != null)
                    {
                        var entity = new Contact()
                        {
                            Content = model.Message,
                            CreateDate = DateTime.Now,
                            FullName = model.FullName,
                            Phone = model.PhoneNumber,
                            Email = model.Email,
                            RegisterFor = registerFor,
                            Slug = model.Slug
                        };

                        _contactRepository.Add(entity);

                        string body = string.Empty;
                        //using streamreader for reading my htmltemplate   
                        using (StreamReader reader = new StreamReader(Path.Combine("wwwroot", "Templetes", "EmailConfirmation.html")))
                        {
                            body = reader.ReadToEnd();
                        }

                        var email = new Email()
                        {
                            Id = Guid.NewGuid(),
                            EmailTo = model.Email,
                            DateCreated = DateTime.Now,
                            NameTo = model.FullName,
                            Subject = $"Your enquiry to TNR Services",
                            Body = body.Replace("[name]", model.FullName)
                        };

                        //  _emailRepository.Add(email);
                        result.Success = true;

                        // result.Message = language.ToUpper() == "EN" ? "Registered successfully" : "Đăng ký thành công";
                        return Ok(result);

                    }
                   

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    return BadRequest(result);
                }
            }
            return BadRequest(result);

        }
    }
}
