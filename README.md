# GoogleContatos.Service
Web API RESTfull para listar os contatos do Google utilizando OAuth2 para autenticação.

# Instruções
1º Executar o método {domínio}/Authentication para obter a URL de autenticação do Google;
2º Redirecionar para URL retornada e pegar o "AccessCode" após a confirmação da permissão pelo usuário.
3º Executar o método {domínio}/Contatos?Code={AccessCode} que irá retornar uma lista de contatos em formato Json.

# {domínio}/Authentication
Retorna a URL de Autenticação do Google que deverá ser executada através de um redirecionamento via browser pela aplicação que efetuou a chamada do método.

# {domínio}/Contatos?Code={AccessCode}
Ao efetuar a chamada desse método passando o "AccessCode" obtido através da autorização de acesso da URL do Google, será retornado uma lista de contatos em formato Json.

# Formato da Lista de Contatos
A lista de contatos retornada pelo serviço terá o seguinte formato:
{
  Id:"Id do Contato",
  Nome:"Nome do Contato",
  TelefonePrincial:"Telefone do Contato",
  Email:"E-mail do contato"
}
