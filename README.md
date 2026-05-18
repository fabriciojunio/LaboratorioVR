# LaboratorioVR

Projeto de faculdade — laboratório de química em Realidade Virtual feito em Unity, com interação por *gaze* (olhar) e suporte a Google Cardboard / giroscópio do celular.

## Scripts principais

Localizados em `Assets/Scripts/`:

- **GazeController.cs** — dispara um *raycast* a partir da câmera para detectar objetos interativos no campo de visão.
- **GazeInteraction.cs** — exibe um painel informativo em tela quando o usuário olha para um objeto por um tempo determinado.
- **TeleportPoint.cs** — ponto de teletransporte ativado por *gaze*; preenche em verde conforme o tempo de olhar e move o *camera rig* para a posição.
- **GyroCam.cs** — controle da câmera por toque ou giroscópio, com botão para alternar os modos. Cria também o cursor central da tela.

## Requisitos

- Unity (versão usada no projeto — ver `ProjectSettings/ProjectVersion.txt`)
- TextMesh Pro (já incluído em `Assets/TextMesh Pro/`)
- Build alvo: Android (Google Cardboard)
