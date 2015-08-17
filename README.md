# eve-intel-map

## momentally just and idea
Show map like in [eve-log-watcher](https://github.com/CzBuCHi/eve-log-watcher) but dont use chatlog for gathering intel.

App will know player current location by checking local chat for system message, when player uses kos check on local players and found some then server request will happend and kos info will be broadcasted to all online clients.

So for example player 'Fred' is mining in 1-1I53. Second player 'Vilma' in R3-K7K find some unknown players in local and perform 'kos check' and find that there is one kos player 'Barney'. App will automatically send information about Barney location to server and he broadcast it back to 'Fred' who starts align to station just in case ...

## idea2: list of all detected kos players in table: 

| Player | Last known system | Ship | Notes |
| --- | --- | --- | --- |
| Barney | R3-K7K (15:13) | unknown | |
| Betty | Misaba (15:03) | Velator (15:08) | hotdropper |

any player can edit Ship and Notes columns and they will be broadcasted to other clients
times in system and ship columns will be inserted automatically by server in EVE-time

## implemented
- server implemented as duplex wcf service hosted on IIS.
- client not implemented yet, just some client-server testing code...
