# Política de Segurança

Este é um projeto acadêmico de aplicativo VR em Unity para Android (Google
Cardboard). Ele não expõe serviços de rede, não coleta dados pessoais e não faz
requisições HTTP; ainda assim, mantemos alguns cuidados básicos.

## Escopo

- Código C# em `Assets/Scripts/`.
- Configuração de build e dependências (`Packages/`, `ProjectSettings/`).

## Como reportar

Encontrou algo sensível (por exemplo, uma credencial commitada por engano ou uma
dependência com vulnerabilidade conhecida)? Abra uma *issue* privada ou use o
recurso de *Security advisory* do GitHub neste repositório. Evite divulgar
detalhes publicamente antes da correção.

## Boas práticas adotadas

- Nenhuma chave de API, token ou senha é versionada. Não faça *commit* de
  segredos; use variáveis de ambiente ou o *keystore* do Android fora do
  controle de versão.
- O `.gitignore` mantém artefatos de build, `Library/`, `Temp/`, `Logs/` e
  arquivos de assinatura (`.keystore`) fora do repositório.
- Dependências externas (Google Cardboard XR, TextMesh Pro) devem ser obtidas de
  fontes oficiais.
