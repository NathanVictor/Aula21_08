using System;
using System.Text;


namespace XulambsFoods {    
    public class Pizza {

        /// <summary>
        /// Lembre-se:
        // ENTENDER O PROBLEMA!!!
        //Regra 0 -- não entre em pânico
        //Regra 1 -- não viaje
        /// </summary>
        /// 
        #region atributos
        int _maxIngredientes;
        double _precoBase;
        int _quantIngredientes;
        double _valorPorAdicional;
        string _descricao;
        #endregion

        #region construtores

        private void Init(int adicionais) {
            _descricao = "Pizza";
            _maxIngredientes = 8;
            _precoBase = 29d;
            AdicionarIngredientes(adicionais);
            _valorPorAdicional = 5d;
        }

        public Pizza() {
            Init(0);
        }

        /// <summary>
        /// Cria uma pizza com a quantidade de adicionais desejada. Em caso de erro, retorna uma pizza sem adicionais.
        /// </summary>
        /// <param name="adicionais">Quantidade de ingredientes da pizza. Deve ser >= 0 e <=8 </param>
        public Pizza(int adicionais) {
            Init(adicionais);
        }
        #endregion

        #region métodos privados
        private double ValorAdicionais() {
            return _valorPorAdicional * _quantIngredientes;
        }

        private void ModificarDescricao() {
            _descricao = $"Pizza com {_quantIngredientes} adicionais";
        }

        private bool PodeAdicionar(int quantos) {
            return (quantos >= 0 &&
                    quantos + _quantIngredientes <= _maxIngredientes);
        }
        #endregion

        #region métodos públicos
        public double CalcularValorFinal() {
            return _precoBase + ValorAdicionais();
        }

        /// <summary>
        /// Tenta adicionar ingredientes à pizza. Faz a validação e, em caso de erros,
        /// não realiza a operação.
        /// </summary>
        /// <param name="quantos">Quantidade de ingredientes a ser adicionada. Deve ser maior ou igual a 0</param>
        /// <returns>A quantidade de ingredientes na pizza após a execução do método.</returns>
        public int AdicionarIngredientes(int quantos) {
            if (PodeAdicionar(quantos)) {
                _quantIngredientes = _quantIngredientes + quantos;
                ModificarDescricao();
            }
            return _quantIngredientes;
        }

        /// <summary>
        /// Gera o cupom de venda da pizza. O cupom contém a descrição com a quantidade de adicionais,
        /// o valor base, o valor dos adicionais e o valor total a pagar.
        /// </summary>
        /// <returns>String com os dados acima</returns>
        public string GerarCupom() {
            StringBuilder cupom = new StringBuilder("Xulambs Pizza!!!\n");
            cupom.AppendLine("================");
            cupom.AppendLine($"{_descricao}");
            cupom.AppendLine($"\tPizza: {_precoBase:C2}");
            cupom.AppendLine($"\t{_quantIngredientes} adicionais : {ValorAdicionais():C2}");
            cupom.AppendLine($"TOTAL: {CalcularValorFinal():C2}");
            cupom.Append("================");
            return cupom.ToString();
        }

        /* String -> valor imutável.
         * 
         *  cupom -----------------> "Xulambs Pizza!!!"
         *                              \---------------> "================"
         *                                                        |
         *                                                        |
         *                        _descricao<---------------------/
         */
        #endregion

    }
}