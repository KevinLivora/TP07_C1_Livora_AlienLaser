# Corrección, Trabajo Práctico N°07, Side Scroller 2D

- **Alumno/a:** Livora
- **Entrega:** `TP07_C1_Livora_AlienLaser`
- **Materia:** Programación con Motores de Videojuegos I
- **Nota TP07:** 8

## 1. Checklist de requisitos

Bloque único: Side Scroller 2D

| #   | Requisito | Estado | Evidencia |
|-----|-----------|--------|-----------|
| R1  | Repositorio nuevo con nombre `TP07_C1_Apellido_Titulo` | ✓ | Carpeta `TP07_C1_Livora_AlienLaser`, `.git/` con 13 commits propios desde `7611212 Initial commit` (2026-10-15) |
| R2  | Proyecto de Unity con el mismo nombre | ✓ | `ProjectSettings/ProjectSettings.asset`, `productName: TP07_C1_Livora_AlienLaser`, y `TP07_C1_Livora_AlienLaser.sln` |
| R3  | Moverse a derecha e izquierda | ✓ | `Assets/Scripts/Player/PlayerController.cs:36` lee el eje y `Move()` setea `linearVelocity` en `FixedUpdate` |
| R4  | El personaje puede disparar | ✓ | `Assets/Scripts/Player/PlayerShooting.cs:35-49`, prefab `Assets/Prefabs/Bullet.prefab` |
| R5  | El personaje puede saltar | ✓ | `Assets/Scripts/Player/PlayerController.cs`, `TryJump()` con `ForceMode2D.Impulse` |
| R6  | Enemigos u obstáculos que quitan vida | ✓ | `Assets/Scripts/Enemy/DamageOnContact.cs`, `PlayerHealth.TakeDamage`, prefabs `Enemy *.prefab` y `Hazard SawHalf.prefab` |
| R7  | Se eliminan con más de 2 disparos, vida y barra visible arriba (Canvas World) | ✓ | `Assets/Data/SlimeData.asset` con `maxHealth: 100` y `PlayerData.asset` con `bulletDamage: 25`. `EnemyHealthBar.cs` y Canvas en World Space en `Enemy Slime.prefab`, `Enemy Ladybug.prefab` y `Enemy Snail.prefab` |
| R8  | ParticleSystem al destruir al enemigo | ✓ | `Assets/Scripts/Enemy/Enemy.cs:36-38`, `deathEffect` asignado a `EnemyDeathEffect.prefab` en los tres prefabs de enemigo |
| R9  | Pickables | ✓ | `Assets/Scripts/Gameplay/Collectible.cs`, prefabs `Key.prefab`, `Star.prefab` y `PowerShot.prefab` |
| R10 | Sonido en todas las acciones | ✓ | Música de gameplay: `MusicPlayer` en `Gameplay.unity` con `dstechnician-confuze-111867.mp3`. Saltar y disparar: `PlayerAudio.cs`. Coleccionable: `PlayKey`, `PlayStar`. Eliminar enemigo: `Enemy.cs:40`. Perder: `GameManager.EndGame` con `gameOverClip`. Todos los clips están asignados en `Assets/Prefabs/AudioManager.prefab` |
| R11 | Volumen configurable desde Settings conectado a un AudioMixer | ✓ | `Assets/Scripts/UI/SettingsController.cs:64-68` hace `mixer.SetFloat`. Tenés 4 parámetros expuestos en `GameMixer.mixer` y el `OutputAudioMixerGroup` asignado en `AudioManager.prefab` |
| R12 | ScriptableObject para datos o configuraciones | ✓ | `PlayerDataSo.cs`, `EnemyDataSo.cs` y 7 `.asset` en `Assets/Data/`. Leés los valores del SO en `PlayerController`, `PlayerShooting`, `PlayerHealth`, `PlayerPowerUps`, `Enemy` y `EnemyPatrol` |
| R13 | Power ups o modificación de jugabilidad | ✓ | `Assets/Scripts/Player/PlayerPowerUps.cs` (invencibilidad y PowerShot), daño alternativo en `PlayerShooting.cs:40` |
| R14 | El personaje está animado | ✓ | `Assets/Art/Animations/Player.controller` con `IsGrounded` y `Speed`, `PlayerRun.anim`, `PlayerJump.anim`, `PlayerIdle.anim` |
| R15 | Escena de menú principal y escena de Gameplay | ✓ | `ProjectSettings/EditorBuildSettings.asset`: `Main Menu.unity` y `Gameplay.unity`. `UiMainMenuManager.OnPlayClick` carga `Gameplay` |

## 2. Cumplimiento de Pautas de Cursada

| ID | Pauta | Estado | Evidencia |
|----|-------|--------|-----------|
| P1 | Unity 6000.3.21f1 | ✓ | `ProjectSettings/ProjectVersion.txt` dice `6000.3.21f1` |
| P2 | Repositorio público | ✓ | El repositorio es público (al 2026-11-16) |
| P3 | Nombre del repo | ✓ | `TP07_C1_Livora_AlienLaser` respeta `TPxx_Cn_Apellido_Titulo` |
| P4 | Código en inglés | ✓ | En los 30 scripts, clases, métodos, campos, enums (`CollectibleType`), tags (`GameTags.Player`) y escenas (`Main Menu`, `Gameplay`) están en inglés |
| P5 | Un repo por TP | ✓ | `git log` tiene 13 commits, todos del TP07. No hay carpetas de otros TPs |

## 3. Estructura de carpetas

| Carpeta esperada | Encontrada | Observación |
|------------------|------------|-------------|
| `Assets/Art/Animations/` | ✓ | 12 `.anim` y `.controller` |
| `Assets/Art/Audio/` | ✓ | `Music/`, `Sfx/`, `GameMixer.mixer` |
| `Assets/Art/Sprites/` | ✓ | Subcarpetas por tipo |
| `Assets/Art/Materials/` | No aplica | El único material físico está en `Assets/Art/Physics/NoFriction.physicsMaterial2D` (carpeta extra, está bien) |
| `Assets/Data/` | ✓ | 7 `.asset` de SO |
| `Assets/Prefabs/` | ✓ | 16 prefabs |
| `Assets/Scenes/` | ✓ | 2 escenas |
| `Assets/Scripts/` | ✓ | Subcarpetas `Audio`, `Data`, `Enemy`, `Gameplay`, `Player`, `UI` en lugar de `Data`, `Game`, `Ui`. Es una organización consistente, está bien |

Archivos mal ubicados:

- `Assets/Art/Sprites/Player/PlayerIdle.anim` va en `Assets/Art/Animations/`, junto a `PlayerRun.anim` y `PlayerJump.anim`.

Ruido de repo (no lo tengo en cuenta):

- `Assets/Settings/Data/`, `Assets/Settings/Gameplay/` y `Assets/Settings/Player/` están vacías.
- `Assets/InputSystem_Actions.inputactions` es de la plantilla y no lo usás (el input es con `UnityEngine.Input`).
- `Assets/Settings/Scenes/URP2DSceneTemplate.unity` es de la plantilla URP.

## 4. Qué le falta

- Detectar cuando el jugador sale del piso sin saltar, para que funcione la animación de caída (`PlayerController.cs:63`).
- Encapsular los campos de `PlayerDataSo` y `EnemyDataSo` con `[SerializeField] private` y properties.
- Un chequeo de piso que no cuente las paredes (`PlayerController.cs:59`).
- Pasar el string `"Gameplay"` a una constante compartida con `"Main Menu"`.
- Poner en el nivel o borrar `CollectibleType.Coin` y `CollectibleType.ExtraLife`.
- Completar en el README la fuente y la licencia de la música, como indica el propio README.

## 5. Hallazgos de código

### Error (0)

### Bug (1)
- `Assets/Scripts/Player/PlayerController.cs:63` `CheckGround()` solo dispara `Landed`. Si el jugador cae de un borde sin saltar, `PlayerAnimator` deja `IsGrounded` en true.

### Warning (7)
- `Assets/Scripts/Data/EnemyDataSo.cs:6` campos `public` mutables en el SO.
- `Assets/Scripts/Data/PlayerDataSo.cs:6` campos `public` mutables en el SO.
- `Assets/Scripts/Player/PlayerController.cs:31` comparación `Time.timeScale == 0f`.
- `Assets/Scripts/Player/PlayerController.cs:59` `IsTouchingLayers` cuenta los contactos laterales como piso.
- `Assets/Scripts/Player/PlayerShooting.cs:27` comparación `Time.timeScale == 0f`.
- `Assets/Scripts/Enemy/DamageOnContact.cs:12` `GetComponent` en cada paso de `OnTriggerStay2D`.
- `Assets/Scripts/UI/UiMainMenuManager.cs:24` nombre de escena `"Gameplay"` como string mágico.

### Suggestion (6)
- `Assets/Scripts/UI/UiPauseMenuManager.cs:19` la constante `"Main Menu"` está duplicada con `GameplayHud.cs`.
- `Assets/Scripts/Gameplay/GameManager.cs:18` singleton sin chequeo de duplicado ni limpieza en `OnDestroy`.
- `Assets/Scripts/Gameplay/CollectibleType.cs:3` `Coin` y `ExtraLife` no se usan en prefabs ni en la escena.
- `Assets/Scripts/Gameplay/Collectible.cs:25` `GetComponent<PlayerPowerUps>()` repetido y sin null check.
- `Assets/Scripts/UI/GameplayHud.cs:64` `SetActive` e interpolación de strings en cada frame.
- `Assets/Scripts/Enemy/Enemy.cs:35` `Instantiate(deathEffect, ...)` sin null check.

## 6. Recomendaciones

1. Corregí `CheckGround()` en `PlayerController.cs` para que avise también cuando el jugador deja el piso, y cambiá `IsTouchingLayers` por un chequeo desde los pies. Con eso resolvés el Bug y un Warning.
2. Encapsulá `PlayerDataSo` y `EnemyDataSo` con `[SerializeField] private` y properties de solo lectura (2 Warnings).
3. Cambiá `Time.timeScale == 0f` en `PlayerController` y `PlayerShooting` por un estado de pausa explícito (2 Warnings).
4. Usá `TryGetComponent` en `DamageOnContact.OnTriggerStay2D` y en `Collectible.Collect`.
5. Creá una clase `SceneNames` con `MainMenu` y `Gameplay` y usala en `UiMainMenuManager`, `UiPauseMenuManager` y `GameplayHud`.
6. Mové `PlayerIdle.anim` a `Assets/Art/Animations/` y borrá las carpetas vacías de `Assets/Settings/`.
