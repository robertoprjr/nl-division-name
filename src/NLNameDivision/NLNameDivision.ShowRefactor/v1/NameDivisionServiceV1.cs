// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.Extensions.Configuration;
//
// namespace NLNameDivision.ShowRefactor.v1
// {
//     internal class NameDivisionServiceV1
//     {
//         
//         private readonly IConfiguration _configuration; 
//         public NameDivisionServiceV1(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }
//         
//         public List<string> ReportParticleList()
//         {
//             var particleConfigValue = _configuration.GetSection("PARTICLE_LIST").Value ?? "";
//             var particleList = particleConfigValue.Split(" ");
//             return particleList.ToList();
//             
//             // foreach (var particle in particleList)
//             // {
//             //     yield return particle;
//             // }
//         }
//     }
// }