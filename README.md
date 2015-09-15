# eve-intel-map (in developend)

## implemented:
server:
- client autentification via eve api key (used to kos-check every character associated with it - no client with kos character allowed)
- clients supose to select all characters in local and send that info to server (via simple shortcut - aka: click in local, CTRL+A, CTRL+SHIFT+A) 
- server will try load kos-information from cache or execute kos-check againts http://kos.cva-eve.org/api for unknown kos statuses and stores them in cache
--- all detected kos characters are broadcsted to all active clients
- also stores ship info and any text node on character
client:
- connection to server, local log file watch for current system detection

## todo:
- server cache expiration (currently data never expires)
- server restart - every day like EVE ... (with cache cleaning?)
- client that dont look like a crap
- map representation in dotlan style with color visualisation of systems with kos players (more players, more red, etc.)

