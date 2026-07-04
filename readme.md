# uzinu 

a better cli for utmodlib, because utmt_cli sucks and i hate it 

## usage

```
uzinu - better cli for utmodlib
usage: ./uz path/to/data.win <verb> [rest of cmdline]
commands:
  list   <block>       - list assets in block (if the assets can't store names, return count)
  decomp <script_name> - decompile script into gml
  disasm <script_name> - disassemble script into vmasm
  find   <string>      - find references to string in decomp

  dump   <block> <meta/data> [asset] [output] - dump asset from block.
    note: omitting asset name dumps entire block into folder.
    note: trying to dump code will decomp by default.
    note: when dumping animated sprites, [output] becomes the folder name.
    note: dumping to console will pretty print!

block list:
  Gen8 - game metadata
  Optn - constant map
  Sond - maps song names to EmbeddedAudio ids
  Agrp - audio groups
  Sprt - sprites
  Bgnd - backgrounds
  Path - paths
  Scpt - maps script names to code ids
  Shdr - shaders
  Font - fonts
  Tmln - timelines
  Objt - game object definitions
  Room - rooms
  Tpag - texture pages
  Code - actual game code
  Vari - variable definitions
  Func - functions
  Strg - string list
  Txtr - spritesheet pointers?
  Audo - embedded audio
```

## roadmap

- [ ] listing
  - [ ] list Sond
  - [ ] list Agrp
  - [ ] list Sprt
  - [ ] list Bgnd
  - [ ] list Path
  - [ ] list Scpt
  - [ ] list Shdr
  - [ ] list Font
  - [ ] list Tmln
  - [ ] list Objt
  - [ ] list Room
  - [ ] list Tpag
  - [x] list Code
  - [ ] list Txtr
  - [ ] list Audo
- [ ] dumping
  - [ ] dump Gen8
  - [ ] dump Optn
  - [ ] dump Sond
  - [ ] dump Sprt
  - [ ] dump Path
  - [ ] dump Scpt
  - [ ] dump Shdr
  - [ ] dump Font
  - [ ] dump Tmln
  - [ ] dump Objt
  - [ ] dump Room
  - [ ] dump Tpag
  - [ ] dump Code
  - [ ] dump Strg
  - [ ] dump Audo
- [ ] underanalyzer
  - [x] decomp
  - [ ] disasm
- [ ] find string in decomp

- [ ] syntax highlighting
- [ ] json output
- [ ] daemon?? for faster chaining????

## license
gpl-v3 because utmodlib forced my hand. i hate it here. this stinks
