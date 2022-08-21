# GC local server

This is a copy of a rewritten version of a groove coaster local server, original version is [here](https://github.com//GC-local-server-rewrite) and it's original version is [here](https://github.com/asesidaa/gc-local-server).


# Dev Setup
> Currently its windows only support (from my understanding of dot net) just because that's what I found that gets us this far already (the code was ripped from a GC nesica emulator, `asesidaa` (the dude who wrote it) helped out a ton too with getting the cert issue figured out). Once we have a better understanding on what the game actually wants, I'll likely re-do it all in rust cause I like pain :zany_face: 

## Steps
1. Basically, clone this repo
2. Install visual studio 2022 (or something similar) with C# support
3. ~Then the hardest part for dotnet noobs (ive never touch c# until starting this lol)~
~getting a local install of `https://github.com/unosquare/embedio/tree/v3.X` (at the time of writing this, `asesidaa` used EmbedIO 3.5.0 which is unreleased)~
~Import it with this guide: https://spin.atomicobject.com/2021/01/05/local-nuget-package/~
(should be auto imported)

> **Static dir (for the web server bit that doesn't upload to git):**
> https://cdn.discordapp.com/attachments/1007413593714741258/1010430344400474133/static.rar
> Extract into: `\llsifasa-nesica-emu\GC-local-server-rewrite\static\wwwroot`

***Game setup:***
> - have game running with jconfig if you want, just make sure it launches
> - have your hosts file (`C:\Windows\System32\Drivers\etc\hosts`) updated with these records:
```
127.0.0.1 cert.nesys.jp
127.0.0.1 cert3.nesys.jp
127.0.0.1 data.nesys.jp
127.0.0.1 nesys.taito.co.jp
127.0.0.1 fjm170920zero.nesica.net
```
- have `NesysService.exe` running as admin with the `-app` flag
- it should launch with the nesica error (without the `llsifasa-nesica-emu` running)
- once you compile and run the repo, then run the game, with the above satisfied, logs should start to show up in the log folder under `D:\system\CmdFile\log` (iirc the game needs a `D:\` drive to store its stuff in)

*This is kinda chaotic, make a thread in the discord for more questions / help needed.*

## Usage
Clone and compile (or use releases if there are any).
Extract anywhere.
If you don't have the modified NesysService.exe, modify the host file, add the domains to your hosts file (above).

- Run nesys as admin with `-app`
- Compile and run this repo
- Run game with jconfig probably

## Config

The config file is ~~GC-local-server-rewrite.exe.config~~ config.json

## Event files

todo

## Missing functions

- [ ] todo

## Difficulty unlocking

todo

## Deleted songs

idk if this exsists yet

## Local network

If your game and server is not on the same computer, try modify in config, change `ServerIp` to your server IP.

From server, open mmc.exe, export certificate named "nesys" and "PREMIUM" with private key and import to game computer.

The cert "nesys" goes into LocalMachine/My and Trusted root, the other only LocalMachine/My.

## Windows 8 Embedded

You will likely have issues getting it to run, if you don't it should simply work with the hosts changes etc. Message me if it doesn't (its currently untested at the moment).

# Web interface

A basic web interface for check scores and set options.

If you want to use the interface besides localhost(127.0.0.1), change in appsettings.json:

```
"BaseUrl": "http://192.168.1.1" // Change to your server ip
```

Notice that due to certificate issues, you need to use http for `BaseUrl` and when accessing the web page, otherwise it will show insecure or fail.

If you really want https all along, make sure you have changed the `ServerIp` and have regenerated the certificate.

# Relay server

Relay server is simple, just run the executable. Default port is 3333, you can change it by provide a command line argument, e.g.

```
./GCRelayServer 12345
```

In main server's config.json, change the following fields to specify the relay server:

```
  "RelayServer": "127.0.0.1", // Server IP
  "RelayPort": 3333, // Server port
```

Currently the server implementation only allow one matching at a time. Notice that if one matching ends abnormally, you will need to restart the main server.
