# AlienLaser

[English](#english) | [Español](#español)

---

## English

2D side scroller made in Unity 6 (6000.3.21f1, URP 2D)

**Play it on itch.io:** https://kevinlivora.itch.io/alienlaser

### Goal

Cross the map, collect the 3 golden keys (one per section) and walk through the door at the end to win.
If you lose all 3 health points, it's Game Over.

### Controls

| Action | Key |
|---|---|
| Move | A / D or arrow keys |
| Jump | Space |
| Shoot | Left mouse click |
| Pause / Audio settings | Esc |

### Mechanics

- **Enemies:** Slime, Ladybug and Snail patrol their platforms. They damage you on contact and die after 4 shots. Each has a health bar above its head and a particle effect on death.
- **Saw:** a fixed, indestructible hazard that damages you on contact.
- **Blue gem (PowerUp):** for 8 seconds your shots are blue and kill in 1 hit.
- **Star:** 5 seconds of invincibility.
- **Keys:** all 3 are needed to open the door.
- **Health:** 3 points, with a short protection window after being hit.
- **Audio:** music, jump, shoot, pickup, kill, life lost, game over and victory sounds. Master, Music, SFX and UI volumes can be adjusted from Settings, also while paused, through an AudioMixer.

### Technical details

- Data stored in ScriptableObjects (PlayerDataSo, EnemyDataSo).
- Event-based communication (HealthChanged, Died, Jumped, Landed) and the IDamageable interface.
- AudioManager singleton with an AudioMixer.
- One-way platforms using Platform Effector 2D.
- 3-layer infinite parallax and a smoothed camera follow with limits.
- World Space Canvas for enemy health bars.

### Credits

- Development: Kevin Livora
- Art and interface sounds: [Kenney.nl](https://kenney.nl) (CC0)
- Music and victory sound: see the files in `Assets/Art/Audio` (dstechnician, emmraan, eaglaxle). Add the source and license of each one.

### Build

WebGL, published on itch.io.

---

## Español

Side scroller 2D hecho en Unity 6 (6000.3.21f1, URP 2D)

**Jugalo en itch.io:** https://kevinlivora.itch.io/alienlaser

### Objetivo

Recorré el mapa, juntá las 3 llaves doradas (una por sección) y entrá por la puerta del final para ganar.
Si perdés los 3 puntos de vida, es Game Over.

### Controles

| Acción | Tecla |
|---|---|
| Moverse | A / D o flechas |
| Saltar | Espacio |
| Disparar | Click izquierdo del mouse |
| Pausa / Ajustes de audio | Esc |

### Mecánicas

- **Enemigos:** Slime, Ladybug y Snail patrullan sus plataformas. Hacen daño al tocarlos y se eliminan con 4 disparos. Tienen barra de vida sobre la cabeza y efecto de partículas al morir.
- **Sierra:** obstáculo fijo e indestructible que hace daño al contacto.
- **Gema azul (PowerUp):** durante 8 segundos tus disparos son azules y matan de 1 golpe.
- **Estrella:** 5 segundos de invencibilidad.
- **Llaves:** hacen falta las 3 para abrir la puerta.
- **Vida:** 3 puntos, con protección breve después de recibir un golpe.
- **Audio:** música, saltar, disparar, recoger, matar, perder vida, game over y victoria. Los volúmenes (Master, Music, SFX, UI) se ajustan desde Settings, también en pausa, con un AudioMixer.

### Detalles técnicos

- Datos en ScriptableObjects (PlayerDataSo, EnemyDataSo).
- Comunicación por eventos (HealthChanged, Died, Jumped, Landed) e interfaz IDamageable.
- AudioManager singleton con AudioMixer.
- Plataformas one-way con Platform Effector 2D.
- Parallax infinito de 3 capas y cámara con seguimiento suavizado y límites.
- Canvas World Space para la barra de vida de los enemigos.

### Créditos

- Desarrollo: Kevin Livora
- Arte y sonidos de interfaz: [Kenney.nl](https://kenney.nl) (CC0)
- Música y efecto de victoria: ver archivos en `Assets/Art/Audio` (dstechnician, emmraan, eaglaxle). Completar con la fuente y licencia de cada uno.

### Build

WebGL, publicado en itch.io.
