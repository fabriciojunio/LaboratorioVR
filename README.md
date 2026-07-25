# LaboratorioVR

Laboratório de química em Realidade Virtual feito em Unity. Projeto de faculdade
com interação por *gaze* (olhar), suporte a Google Cardboard e controle por
giroscópio do celular.

## Sobre

O usuário explora um ambiente 3D de laboratório usando um óculos Cardboard (ou
apenas a tela do celular). A navegação e a interação são feitas apenas com o
olhar: ao mirar um objeto por alguns instantes, um painel informativo aparece;
ao mirar um ponto de teletransporte, o piso se preenche de verde e a câmera é
movida para o local.

## Requisitos

- Unity **2022.3.62f3** (LTS). A versão exata está em `ProjectSettings/ProjectVersion.txt`.
- Módulo de build **Android** instalado pelo Unity Hub (o alvo é o Google Cardboard).
- TextMesh Pro (já incluído em `Assets/TextMesh Pro/`).
- Plugin **Google Cardboard XR** (ver observação abaixo).

## Dependência do Google Cardboard XR (importante)

O `Packages/manifest.json` referencia o plugin do Cardboard por um caminho local
da máquina do autor:

```json
"com.google.xr.cardboard": "file:C:/Users/.../cardboard-xr-plugin-1.30.1/..."
```

Esse caminho não existe em outras máquinas, então quem clonar o projeto precisa
apontar a dependência para onde o plugin estiver. Opções:

1. Baixar o `cardboard-xr-plugin` (versão 1.30.1) e ajustar o caminho `file:` no
   `Packages/manifest.json` para a pasta local.
2. Ou instalar via Package Manager pela URL do repositório oficial
   (`https://github.com/googlevr/cardboard-xr-plugin`) usando *Add package from git URL*.

Sem esse plugin o projeto não resolve as dependências de XR ao abrir.

## Como abrir

1. Abra o Unity Hub e adicione a pasta do projeto.
2. Use a versão **2022.3.62f3** (ou a mesma LTS 2022.3 mais próxima disponível).
3. Ajuste a dependência do Cardboard XR conforme a seção acima.
4. Cenas disponíveis:
   - `Assets/Scenes/SampleScene.unity` (cena de interação com os scripts de *gaze*).
   - `Assets/3D Laboratory Environment with Appratus/Scenes/Laboratory Scene.unity`
     (ambiente do laboratório).

## Controles

- **Sem giroscópio:** arraste um dedo na tela para girar a câmera.
- **Com giroscópio:** ative o botão "Giroscópio: ON" no canto inferior direito e
  mova o aparelho para olhar em volta.
- **Interação:** mantenha o ponto central da tela sobre um objeto para ver a
  informação ou acionar o teletransporte.

## Build para Android

1. `File > Build Settings`, plataforma **Android**.
2. Confirme o XR Plug-in Management com o provider do Cardboard ativo.
3. Gere o APK. Arquivos de build (`.apk`, `.aab`) são ignorados pelo Git.

## Scripts (`Assets/Scripts/`)

- **GazeController.cs** dispara um *raycast* a partir da câmera para detectar
  objetos interativos no campo de visão.
- **GazeInteraction.cs** exibe um painel informativo em tela quando o usuário
  olha para um objeto por um tempo determinado.
- **TeleportPoint.cs** ponto de teletransporte ativado por *gaze*; preenche em
  verde conforme o tempo de olhar e move o *camera rig* para a posição.
- **GyroCam.cs** controle da câmera por toque ou giroscópio, com botão para
  alternar os modos. Cria também o cursor central da tela.

## Estrutura

```
Assets/
  Scripts/                             scripts C# de interação
  Scenes/                              cena de interação (SampleScene)
  3D Laboratory Environment.../        pacote de modelos, texturas e cena do laboratório
  TextMesh Pro/                        pacote TMP (incluído)
  XR/                                  configurações de XR
  Plugins/Android/                     templates Gradle
Packages/                              manifesto de dependências
ProjectSettings/                       configurações do projeto Unity
```

## Créditos e licenças de terceiros

- O pacote **3D Laboratory Environment with Appratus**
  (`Assets/3D Laboratory Environment with Appratus/`) é de terceiros e mantém a
  licença do seu autor original. Veja o texto em
  `Assets/3D Laboratory Environment with Appratus/Documentation/`.
- **TextMesh Pro** e o **Google Cardboard XR plugin** seguem suas próprias
  licenças da Unity e do Google.

A licença deste repositório (arquivo `LICENSE`) cobre apenas o código original do
autor, ou seja, os scripts em `Assets/Scripts/`.

## Licença

Código próprio sob licença MIT. Consulte o arquivo `LICENSE`.
