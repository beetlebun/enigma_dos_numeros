using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Resources
{
    public class Region
    {
        public string name;
        public string mapName;
        public int num;
        public bool active;

        public Region(string name, string mapName, int num)
        {
            this.name = name;
            this.mapName = mapName;
            this.num = num;
            this.active = true;
        }
    }

    public static List<Region> regions = new List<Region>() { 
        new("Praia_do_Norte", "Mapa_1", 34),
        new("Penhasco_do_Mar", "Mapa_1", 12),
        new("Pinheiros", "Mapa_1", 27), 
        new("Cachoeira", "Mapa_1", 19),
        new("Campos", "Mapa_1",22),
        new("Rocha_da_Terra", "Mapa_1",45),
        new("Tel_Mithryn", "Mapa_1", 42),
        new("Praia_do_Sul", "Mapa_1",37),
        new("Mausoleu_das_Montanhas", "Mapa_2", 87),
        new("Ruinas_do_Deserto", "Mapa_2", 72),
        new("Bosque_Litoraneo", "Mapa_2", 99),
        new("Praia_do_Leste", "Mapa_2", 52),
        new("Rochedo", "Mapa_2", 64),
        new("Planicies_Nevadas", "Mapa_3", -39),
        new("Tundra", "Mapa_3", 229),
        new("Picos_Congelados", "Mapa_3", -99),
        new("Lago_Zurich", "Mapa_3", 502),
        new("Taiga", "Mapa_3", 432)
    };

    public static List<Region> getRegions()
    {
        return regions;
    }
}
