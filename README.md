# MangMadu Game Project

## Ülevaade
MangMadu on lihtne konsoolipõhine mäng, mis simuleerib läbi võrgu navigeerivat madu, joonistades figuure ja seinu. Mängija kontrollib madu nooleklahvide abil ning mäng kontrollib kokkupõrkeid seintega ja mao enda saba.

### Figures Kaust
See kaust sisaldab põhimängu objekte:
- `Figure.cs`: Baasklass kõikidele mänguobjektidele
- `HorizontalLine.cs`: Esindab horisontaalseid jooni mängumaailmas
- `VerticalLine.cs`: Esindab vertikaalseid jooni mängumaailmas
- `Snake.cs`: Joonista maotaoline olend
- `Walls.cs`: Haldab mängumaailma piire

### Food Kaust

See kaust sisaldab klasse, mis on seotud toidukaupadega mängus:

- `FoodCreator.cs`: Juhtib toidukaupade loomist
- `NewFood.cs`: Esindab üksikuid toidukaupu

### Levels Kaust

See kaust sisaldab erinevaid raskusastmeid määratlevaid klasse:

- `BaseLevel.cs`: Tasememääratluste abstraktne baasklass
- `EasyLevel.cs`: Kerge raskusastme rakendamine
- `MediumLevel.cs`: Keskmise raskusastme rakendamine
- `HardLevel.cs`: Raske raskusastme rakendamine

### MainFunctions Kaust

See kaust sisaldab mängu peamist funktsionaalsust:

- `Menu.cs`: Käsitleb peamenüüd ja mänguvoogu
- `players.cs`: Juhib mängija tulemus ja salvestab need faili
- `Sound.cs`: Juhib heli taasesitamist erinevate mänguhelide ja muusika jaoks

### Music Kaust
See kaust sisaldab mp3 faile mängu jaoks

### MangMaduV2
- `Program.cs`: Sisaldab põhimeetodit, initsialiseerides mängu ja kuvades menüü.
- `Direction.cs`: Loendus, mis määrab mao liikumissuuna (LEFT, RIGHT, UP, DOWN).
- `Tulemus.txt`: Fail, kus salvestatakse kõik tulemused ja nimed
