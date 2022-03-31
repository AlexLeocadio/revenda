using MassTransit;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Consumer.Email;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Senior.Revenda.Consumer.Consumers
{
    public class VeiculoConsumer : IConsumer<VeiculoDTO>
    {
        public async Task Consume(ConsumeContext<VeiculoDTO> context)
        {
            try
            {
                string title = InformarTitulo(context);
                string body = InformacaoCadastro(context);

                await SendEmail.SendAsync(title, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar Email");
                Console.WriteLine(ex.Message);
            }
        }

        private static string InformarTitulo(ConsumeContext<VeiculoDTO> context)
        {
            return $"Veículo cadastrado - {context.Message.Marca?.Nome} {context.Message.Modelo}";
        }

        private static string InformacaoCadastro(ConsumeContext<VeiculoDTO> context)
        {
            var body = new StringBuilder();

            body.AppendLine($"Olá,  {context.Message.Proprietario?.Nome}");
            body.AppendLine($"Foi realizado o cadastro do veículo com sucesso. ");
            body.AppendLine("Informações do veículo: ");
            body.AppendLine($"Modelo: {context.Message.Modelo} ");
            body.AppendLine($"Marca: {context.Message.Marca?.Nome} ");
            body.AppendLine($"Ano: {context.Message.AnoFabricacao}/{context.Message.AnoModelo} ");
            body.AppendLine($"Quilometragem: {context.Message.Quilometragem} ");
            body.AppendLine($"Valor: {context.Message.Valor} ");
            body.AppendLine("Att, Alex Costa");

            return body.ToString();
        }
    }
}
