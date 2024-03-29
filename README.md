# Loupedeck plugin for Discord
> This is not an official Discord plugin.

This plugin allows you to control microphone and headphones muting via keyboard shortcuts, and because this plugin doesn't interface with an API, it simulates the behavior of these actions and displays the buttons in the predicted state without actual feedback.

The logic for changing state between microphone and headphones follows the same logic as Discord. So as long as actions are only taken from the Loupedeck, states remain synchronized with Discord.

Discord no longer offers an API ([SDK deprecated](https://discord.com/developers/docs/game-sdk/discord-voice), [RPC in beta](https://discord.com/developers/docs/topics/rpc)), so this project offers an intermediate solution.

## Installation
- Download the [latest release](https://github.com/insideGen/Loupedeck-Discord-OpenPlugin/releases/latest) of the `.lplug4` asset;
- Double-click on the file and follow the instructions in the Loupedeck application.

Only available for Windows, tested with Loupedeck Live S.

## Actions
4 actions are provided:

### Display microphone state
> Adjusment action without reset

**Displays** microphone mute state during adjustment (but doesn't adjust audio volume).

### Display headphones state
> Adjusment action without reset

**Displays** headphones mute state during adjustment (but doesn't adjust audio volume).

### Mute/Unmute microphone
> Command action

**Displays** microphone mute state and **toggles** it when pressed.

| Parameter                            | Type        | Description         |
| ------------------------------------ | ----------- | ------------------- |
| Keyboard shortcut to mute microphone | KeyboardKey |                     |
| Keyboard layout identifier           | Number      | -1 is default value |

### Mute/Unmute headphones
> Command action

**Displays** headphones mute state and **toggles** it when pressed.

| Parameter                            | Type        | Description         |
| ------------------------------------ | ----------- | ------------------- |
| Keyboard shortcut to mute headphones | KeyboardKey |                     |
| Keyboard layout identifier           | Number      | -1 is default value |

## License

This code is under MIT license except Discord logo, icon and wordmark.
For more information about Discord branding, visit [https://discord.com/branding](https://discord.com/branding).
