# Weapon Skill Keys

Adds 2 keybinds: one for a mainhand and one for an off-hand weapon specific attack skill. 
Each keybind uses a skill depending on the currently equipped weapon.  
When a pistol is equipped, the off-hand button for Fire/Reload needs to be held to reload the pistol (to prevent accidental reload). This is optional, enabled by default.  
*Note: The mod does not add any new quick slots, the keybinds trigger the skills on their own.*

It's strongly recommended to use Outward Config Manager to set HUD element position.

## Weapon skills
### Main hand weapon skills
- **One-Handed Axe**: Talus Cleaver
- **Two-Handed Axe**: Execution
- **Bow**: Evasion Shot
- **One-Handed Mace**: Mace Infusion
- **Two-Handed Mace**: Juggernaut
- **Polearm**: Moon Swipe
- **Spear**: Simeon's Gambit
- **One-Handed Sword**: Puncture
- **Two-Handed Sword**: Pommel Counter
- **Gauntlet**: Prismatic Flurry 

### Off-hand weapon skills
- **Chakram**: Chakram Pierce
- **Dagger**: Dagger Slash
- **Pistol**: Fire / Reload *(Note: By default, the button needs to be held to reload the pistol)*
- **Shield**: Shield Charge
- **Lantern/Torch**: Flamethrower

Using the off-hand skill button with a **Lexicon** equipped has no effect.  
*Note: You still have to learn the skill before you can use it.*

## Planned Features
- Potentially include Weapon Master skills
- Drag-and-drop HUD element repositioning
- Split screen support
- Option to resize HUD elements
- Update UI when skill is learned (right now it only shows up when the player re-equips the weapon)
- Ability to change what skill is executed for each weapon (select from a list of weapon-specific skills)
- Torch and Lantern check in a more compatible manner

## Changelog

### v1.4.2
- Torch and Lantern skill added (Flamethrower). This is an unstable/experimental feature. If anything breaks, use the previous version.

### v1.4.1
- Weapon skill keys no longer trigger when a menu is open

### v1.4.0
- Hold off-hand button to reload pistol (to prevent accidental reload in the middle of combat)
- Option to hide HUD elements instead of showing empty when the skill is not learned or there is no weapon in that slot

### v1.3.1
- Bullet count display no longer visible after unequipping pistol
- Cooldown display no longer visible after unequipping weapon
- "New skill" indicator is no longer visible

### v1.3.0
- Fire/reload now shows bullet count and the proper image based on the pistol's state
- Fix for a possible bug where the keybinds didn't work because of DE

### v1.2.1
- Definitive Edition support (vanilla might still work, untested)

### 1.2.0
- Ability to reposition the HUD elements

### 1.1.1
- Fixed endless loading screen when starting a new game

### 1.1.0
- Show current weapon skills and their cooldowns on the HUD

### 1.0.0
- Initial release