
/**
 * Session variable feature currently doesn't work
 * 
 */



//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cors;

//namespace backend.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class SessionController : ControllerBase
//    {

//        private readonly IHttpContextAccessor context;

//        public SessionController(HttpContextAccessor icontext)
//        {
//            context = icontext;
//        }



//        [EnableCors("_myAllowSpecificOrigins")]
//        [HttpGet]
//        public IEnumerable<string> GetSessionInfo(string resUsername)
//        {
//            List<string> sessionInfo = new List<string>();

//            try
//            {
//                //var host = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";

//                if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString(SessionVariables.SessionKeyUsername)))
//                {
//                    context.HttpContext.Session.SetString(SessionVariables.SessionKeyUsername, resUsername);
//                    context.HttpContext.Session.SetString(SessionVariables.SessionKeySessionId.ToString(), Guid.NewGuid().ToString());
//                }
//                var username = context.HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
//                var sessionID = context.HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);

//                sessionInfo.Add(username);
//                sessionInfo.Add(sessionID);
//            }
//            catch (Exception ex) {
//                Console.WriteLine("Error: " + ex.ToString());

//            }

            

//            return sessionInfo;
//        }
//    }
//}
