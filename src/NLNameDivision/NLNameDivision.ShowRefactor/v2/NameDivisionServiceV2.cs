// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.Extensions.Configuration;
// using NLNameDivision.Constant;
//
// namespace NLNameDivision.ShowRefactor.v2
// {
//     public class NameDivisionServiceV2
//     {
//         private readonly IConfiguration _configuration; 
//         public NameDivisionServiceV2(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }
//
//         /// <summary>
//         /// Deixamos a função com apenas o retorno dos dados
//         /// </summary>
//         /// <returns></returns>
//         public List<string> ReportParticleList() =>
//             GetParticleList();
//
//         /// <summary>
//         /// Separando a função de retorno da função de busca das informações temos maior clareza na codificação
//         /// Usamos melhor a linguagem ubiquoa e a responsabilidade única
//         /// </summary>
//         /// <returns></returns>
//         private List<string> GetParticleList() =>
//             SplitParticleListConfigValue(GetParticleListConfigValue()).ToList();
//         
//         // {
//         //     var particleList = SplitParticleListConfigValue(GetParticleListConfigValue());
//         //     foreach (var particle in particleList)
//         //         yield return particle;
//         // }
//
//         private string GetParticleListConfigValue() =>
//             _configuration.GetSection(NameDivisionConstant.ParticleListEnvironmentVariable).Value ??
//             NameDivisionConstant.ParticleListDefault;
//
//         private string[] SplitParticleListConfigValue(string particleConfigValue) =>
//             particleConfigValue.Split(NameDivisionConstant.ParticleListSplitChar);
//     }
// }
