using System;
using System.Collections.Generic;
using System.Text;

namespace Bots.MegaSena.Json
{
    public class ContestResult
    {
        public string ProximoConcurso { get; set; }
        public string ConcursoAnterior { get; set; }
        public object Forward { get; set; }
        public List<object> Mensagens { get; set; }
        public int Concurso { get; set; }
        public long Data { get; set; }
        public string Resultado { get; set; }
        public int Ganhadores { get; set; }
        public int Ganhadores_quina { get; set; }
        public int Ganhadores_quadra { get; set; }
        public double Valor { get; set; }
        public double Valor_quina { get; set; }
        public double Valor_quadra { get; set; }
        public int Acumulado { get; set; }
        public double Valor_acumulado { get; set; }
        public long Dtinclusao { get; set; }
        public string Prox_final_zero { get; set; }
        public double Ac_final_zero { get; set; }
        public object ProxConcursoFinal { get; set; }
        public object Observacao { get; set; }
        public string Rowguid { get; set; }
        public string Ic_conferido { get; set; }
        public string De_local_sorteio { get; set; }
        public string No_cidade { get; set; }
        public string Sg_uf { get; set; }
        public double Vr_estimativa { get; set; }
        public long Dt_proximo_concurso { get; set; }
        public double Vr_acumulado_especial { get; set; }
        public double Vr_arrecadado { get; set; }
        public bool Ic_concurso_especial { get; set; }
        public bool Error { get; set; }
        public bool RateioProcessamento { get; set; }
        public bool SorteioAcumulado { get; set; }
        public string ConcursoEspecial { get; set; }
        public object GanhadoresPorUf { get; set; }
        public string ResultadoOrdenado { get; set; }
        public string DataStr { get; set; }
        public string Dt_proximo_concursoStr { get; set; }
    }
}
