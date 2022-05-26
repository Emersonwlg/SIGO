using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.Models
{
    public class ResponseArquivoViewModel
    {
        [JsonProperty("success")]
        public bool success { get; set; }

        [JsonProperty("data")]
        public IEnumerable<ArquivoViewModel> Data { get; set; }
    }

    public class ArquivoViewModel
    {
        [JsonProperty("normaId")]
        public Guid NormaId { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("caminhoArquivo")]
        public string CaminhoArquivo { get; set; }

        [JsonProperty("normaExterna")]
        public string NormaExterna { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
