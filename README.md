# Tryitter
#### Versão simplificada do backend de uma rede social totalmente baseada em texto.

### Descrição:
O objetivo do Tryitter é proporcionar um ambiente em que pessoas estudantes poderão, por meio de textos e imagens, compartilhar suas experiências e também acessar posts que possam contribuir para seu aprendizado.

#### Autores desse projeto:

- [Breno Albuquerque](https://github.com/breno-albuquerque)
- [Quesia Mendes](https://github.com/Ques-Mendes)
- [Francinele Oliveira](https://github.com/Fran-C-Oliveira)

## Iniciando

Clone o projeto

```zsh
git clone git@github.com:breno-albuquerque/FinalProjectTryitter.git
```
### Pré-requisitos
- .Net Core
- SDK do .Net
- IDE configurada para .Net
- Docker
- SQL Server

## Como instalar e preparar sua máquina para esse projeto?
  <b>Observação</b>: <i>Este guia supõe que você esteja usando o Ubuntu 20.04.
    Em função das diversas distribuições do Linux, é recomendado pesquisar as instruções de instalação específicas para sua distribuição.</i>

### - Instale o .Net Core: 
Para realizar o download do pacote Microsoft em .deb, execute:

```zsh
wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
``` 

Para instalar o pacote Microsoft com o dpkg, execute o seguinte comando:

```zsh
sudo dpkg -i packages-microsoft-prod.deb
``` 

### - Instalando o SDK

O SDK é o que permite o desenvolvimento dos aplicativos na plataforma do .NET. Para sua instalação, siga o passo a passo abaixo:

1. Atualize os repositórios no Ubuntu:
```zsh
sudo apt-get update
``` 
2. Garanta que o pacote de transferência segura está instalado:
```zsh
sudo apt-get install -y apt-transport-https
``` 
3. Atualize novamente os repositórios no Ubuntu:
```zsh
sudo apt-get update
``` 
4. Instale o SDK do .NET na versão 6.0:

```zsh
sudo apt-get install -y dotnet-sdk-6.0
``` 
Para testar se o .NET Core foi instalado com sucesso, execute o comando:
```zsh
dotnet --info
``` 

### - Configurando a IDE 
Com o .NET Core instalado, vamos configurar a IDE para trabalhar com C#(neste guia, utilizamos o VS Code como exemplo).

Para configurar todo suporte de marcação de sintaxe, IntelliSense, definições e Debugging para o C#, siga o passo a passo:

1. Abra o VS Code.
2. Vá para a aba de extensões, utilize o atalho ``"ctrl + shift + x"`` no Windows e Linux ou ``"⌘ + shift + x"`` no macOS. Procure por ``"C# Microsoft"`` ou acesse pela [Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp). 
3. Instale a extensão.
4. Reinicie o VS Code.

<i> A extensão provida pela Microsoft já se encarrega de baixar e instalar todas as dependências. </i> 

### - Preparando a IDE para trabalhar com Docker

1. Instale as dependências para o Docker, garantindo que o pacote de transferência segura está instalado:

  1.1. Instale os pré-requisitos de certificado:

```zsh
sudo apt install apt-transport-https ca-certificates curl software-properties-common 
``` 
  1.2. Adicione a chave GPG para o repositório oficial do Docker no seu Ubuntu:

```zsh
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -
``` 
   1.3. Por fim, adicione o repositório do Docker às fontes do APT:
```zsh
sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu focal stable"
``` 
2. Instale o Docker no Ubuntu:
```zsh
sudo apt-get install docker-ce docker-ce-cli containerd.io
``` 
3. Abra o VS Code.
4. Vá para a aba de extensões, utilize o atalho ``"ctrl + shift + p"`` no Windows e Linux ou ``"⌘ + shift + P"`` no macOS.
5. Procure por "Docker" ou acesse pela [Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker).
6. Instale a extensão.
7. Reinicie o VS Code.

Para testar se o docker foi instalado corretamente, execute o comando:
```zsh
docker version
``` 

### - SQL Server

<br>

#### >> Para testar as requisições HTTP, você pode utilizar o Postman ou ferramentas similares.

  Baixe e instale o Postman na versão mais adequada para seu sistema [neste link](https://www.postman.com/downloads/) (É recomendado que você crie uma conta gratuita e faça login).
  Caso precise de ajuda, siga as instruções [neste link](https://atendimento.tecnospeed.com.br/hc/pt-br/articles/360017143594-Como-instalar-e-utilizar-o-Postman-para-enviar-requisi%C3%A7%C3%B5es-HTTP). 

##
# Sobre como essa aplicação foi desenvolvida

A arquitetura foi pensada da seguinte forma:

![image](https://user-images.githubusercontent.com/93018956/207479342-fd60243e-9f9a-4f11-9c70-123f0d4ed461.png)

Conforme visto na imagem acima, haverá um Front-End que será responsável por interagir com as pessoas estudantes e mandar as requisições para o Back-End (o presente projeto), que, por sua vez, será responsável por manter as informações atualizadas em um banco de dados MySQL Server usando o Entity Framework.

Nessa rede social, as pessoas estudantes devem conseguir se cadastrar com nome, e-mail, módulo atual que estão estudando no curso da Trybe e senha para se autenticar. Deve ser possível, também, alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.

Uma pessoa estudante deve poder também publicar posts em seu perfil, que poderão conter texto com até 300 caracteres e arquivos de imagem, além de conseguir pesquisar outras contas por nome e optar por listar todos seus posts ou apenas o mais recente.

##
# As rotas presentes nessa aplicação são: 

- POST `/cadastro` - para cadastros de novos usuários;
- POST `/login` - para login de usuários já cadastrados;

##
 - Foi desenvolvida uma autenticação utilizando `JWT Bearer`, necessária para todas as demais rotas além de `Cadastro` e `Login`;  
 - Os testes foram desenvolvidos utilizando os frameworks <b>`xUnit`</b> e <b>`FluentAssertions`</b>. 
