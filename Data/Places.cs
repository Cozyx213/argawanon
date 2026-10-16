using MyBlazorApp.Models;

namespace MyBlazorApp.Data;

// Read-only sample content. Nothing here changes while the app runs,
// so a static list is safe to share between visitors.
public static class Places
{
    public static readonly string[] Categories = ["Attractions", "Food", "Stays"];

    public static Place? Find(string slug) =>
        All.FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

    public static readonly IReadOnlyList<Place> All =
    [
        // Attractions: real public places in Argao.
        new("argao-church", "Saint Michael the Archangel Parish Church", "Attractions", "Poblacion, Argao",
            "A coral-stone church at the heart of Argao's heritage town center.",
            "Built during the Spanish colonial period, Argao's parish church is one of Cebu's well-known coral-stone churches. Its bell tower, carved façade and painted ceiling make it a favorite stop on a heritage walk. It is an active place of worship, so dress modestly and keep quiet during services.",
            "images/church.jpg", "Stone façade and bell tower of Argao's parish church behind a brick path and garden.",
            "Photo: Patrickroque01, Wikimedia Commons, CC BY-SA 4.0", false,
            [new("Mara (sample)", 5, "The stone façade is beautiful up close. We spent a long time looking at the ceiling.", true),
             new("Joel (sample)", 4, "A peaceful start to our heritage walk around the plaza.", true)]),

        new("argao-town-plaza", "Argao Town Plaza", "Attractions", "Rizal Street, Poblacion, Argao",
            "Shady lawns and heritage buildings around the town hall.",
            "The plaza connects the church with Argao's municipal hall and other civic buildings along Rizal Street. Its trees, open lawns and brick walkways make it an easy place to rest between stops and watch everyday town life.",
            "images/plaza.jpg", "Brick walkway and green lawn of Argao's town plaza, with the red-roofed municipal hall behind the trees.",
            "Photo: Patrickroque01, Wikimedia Commons, CC BY-SA 4.0", false,
            [new("Ana (sample)", 4, "Nice shade in the afternoon and lots of space to walk.", true),
             new("Rico (sample)", 4, "Good place to sit after visiting the church.", true)]),

        new("argao-shoreline", "Argao Shoreline", "Attractions", "Coastal Argao",
            "Calm water and wide skies along the Bohol Strait.",
            "Argao sits on the southeastern coast of Cebu, facing the Bohol Strait. Early mornings and evenings along the shore are peaceful times for a walk and for watching the sky change color over the water. Swim only in safe, permitted areas and take your trash home with you.",
            "images/shore.jpg", "Silhouetted tree branches over calm blue sea at dusk on the Argao shore.",
            "Photo: George Parrilla, Wikimedia Commons, CC BY 2.0", false,
            [new("Liza (sample)", 5, "The sunset colors over the water were unforgettable.", true),
             new("Ben (sample)", 4, "Quiet and relaxing. Bring water and a hat.", true)]),

        // Food: fictional demonstration listings featuring local dishes.
        new("sikwate-corner", "Sikwate Corner", "Food", "Poblacion, Argao",
            "Thick hot chocolate with sticky rice, a Cebuano breakfast classic.",
            "This is a demonstration listing showing how a breakfast spot could appear on Argawanon. Sikwate is hot chocolate made from tablea (pure cacao tablets), often enjoyed with puto maya or suman, two kinds of sticky rice. The place is fictional, so no menu, prices or opening hours are given.",
            "images/sikwate.jpg", "Cup of dark hot chocolate beside sticky rice wrapped in a banana leaf.",
            "Photo: George Parrilla, Wikimedia Commons, CC BY 2.0", true,
            [new("Celia (sample)", 5, "Rich, thick sikwate. Perfect with the sticky rice.", true),
             new("Mark (sample)", 4, "A cozy breakfast idea for a rainy morning.", true)]),

        new("tablea-pasalubong", "Tablea Pasalubong Stall", "Food", "Poblacion, Argao",
            "Take home cacao tablets to make your own sikwate.",
            "This is a fictional pasalubong (take-home gift) stall. Tablea, roasted and ground cacao pressed into tablets, is a popular Cebuano treat to bring home. Argao is also known for torta, a soft and sweet local cake that makes another classic pasalubong.",
            "images/tablea.jpg", "Bags of dark tablea cacao tablets packed for sale.",
            "Photo: Obsidian Soul, Wikimedia Commons, CC0", true,
            [new("Grace (sample)", 5, "Bought tablea for my family and made sikwate at home.", true),
             new("Paolo (sample)", 4, "Great gift idea. Ask how to prepare it.", true)]),

        new("baybayon-kinilaw", "Baybayon Kinilaw Kitchen", "Food", "Coastal Argao",
            "Fresh fish cured in vinegar and citrus.",
            "This is a fictional seaside kitchen. Kinilaw is a Visayan dish of raw fish cured in vinegar or citrus juice with onion, ginger and chili. It is bright, sour and refreshing on a warm day.",
            "images/kinilaw.jpg", "Bowl of kinilaw with cubed fish, tomato, onion and green chili.",
            "Photo: whologwhy, Wikimedia Commons, CC BY 2.0 (taken in Carcar, Cebu)", true,
            [new("Nina (sample)", 5, "Fresh and tangy. Exactly what I wanted after the beach.", true),
             new("Arnel (sample)", 3, "Tasty, but a little too sour for me.", true)]),

        // Stays: fictional demonstration listings. Photos show Argao scenery, not the properties.
        new("lantawan-seaside-cottages", "Lantawan Seaside Cottages", "Stays", "Coastal Argao",
            "Simple cottages for slow mornings by the sea.",
            "This is a demonstration listing for a seaside stay. Imagine waking up to the sound of the water and walking out for an early view of the Bohol Strait. The property is fictional; no rates, amenities or availability are given.",
            "images/coastal-area.jpg", "Wooden boardwalk leading over calm water toward thatched huts.",
            "Photo: Constantine Agustin, Wikimedia Commons, CC BY-SA 2.0. It shows Argao's coast, not this fictional property.", true,
            [new("Ella (sample)", 5, "So calm. We loved the sea breeze.", true),
             new("Tom (sample)", 4, "A relaxing idea for a weekend away.", true)]),

        new("balay-sa-dagat-homestay", "Balay sa Dagat Homestay", "Stays", "Coastal Argao",
            "A homestay-style idea for travelers who want to slow down.",
            "This is a demonstration listing. \"Balay sa dagat\" means \"house by the sea\" in Cebuano. A homestay lets visitors learn about local daily life from their hosts. The property is fictional; no rates, amenities or availability are given.",
            "images/coastal-dwellings.jpg", "Stilt houses with thatched and tin roofs standing over shallow turquoise water.",
            "Photo: Constantine Agustin, Wikimedia Commons, CC BY-SA 2.0. It shows Argao's coast, not this fictional property.", true,
            [new("Jun (sample)", 4, "A homestay is a great way to experience local life.", true),
             new("Kat (sample)", 4, "Peaceful and simple.", true)]),

        new("kabilin-heritage-inn", "Kabilin Heritage Inn", "Stays", "Poblacion, Argao",
            "Stay within walking distance of the church and plaza.",
            "This is a demonstration listing. \"Kabilin\" means \"heritage\" in Cebuano. A stay in the town center would put the church, plaza and heritage houses within an easy walk. The property is fictional; no rates, amenities or availability are given.",
            "images/town.jpg", "Two-story stone heritage house with a red tile roof beside a quiet street and lawn.",
            "Photo: Constantine Agustin, Wikimedia Commons, CC BY-SA 2.0. It shows a heritage house in Argao, not this fictional property.", true,
            [new("Rosa (sample)", 5, "Loved being able to walk everywhere in town.", true),
             new("Dan (sample)", 4, "Quiet nights and old houses all around.", true)]),
    ];
}
