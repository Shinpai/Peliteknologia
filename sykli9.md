## Raportti - Shader ohjelmointi

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

---
Tavoitteena oli ymmärtää shader-ohjelmoinnin perusteet ja oppia renderöimään yksinkertaisia 2d-muotoja shaderia käyttäen. Otin tehtävään tavoitteeksi 3p suorituksen: 2 eriväristä muotoa jotka reagoivat hiireen. Tutoriaaleja ja dokumentaatiota shadertoyn käyttöön löytyi suht vähän, joten kävin etsimään youtubesta ja muualta esimerkkejä siitä, miten yksinkertaisia juttuja työkalulla oli tehty. Löysin muutaman hyvän esimerkin, joista yhden pohjalle lähdin sitten rakentamaan omaa juttua. 

Koetin pitää oman tekemisen mahdollisimman yksinkertaisena, koska minulla ei ollut mitään aikaisempaa kosketusta shader-ohjelmointiin. Esimerkkien avulla sain piirrettyä ympyrän ja renderöityä sen ruudulle, toistin tämän toiselle eriväriselle ympyrälle toiseen paikkaan. Sen jälkeen piti etsiä miten hiiren klikkauksiin/positioon pääsee käsiksi. Yhdistin sen luomiini ympyröihin siten, että ympyröiden halkaisijat reagoivat hiiren positioon. Ympyrä1 ottaa kokonsa hiiren y-akselista ja taas ympyrä2 x-akselista.

```GLSL
/**
 * Piirtää ympyrän
 */
vec4 circle(vec2 uv, vec2 pos, float rad, vec3 color) {
	float d = length(pos - uv) - rad;
	float t = clamp(d, 0.0, 1.0);
	return vec4(color, 1.0 - t);
}

void mainImage( out vec4 fragColor, in vec2 fragCoord ) {
	vec2 uv = fragCoord.xy;
	vec2 center = iResolution.xy * 0.5;
    // kaksi eri halkaisijaa hiiren x- ja y- positiosta
    float rad1 = iMouse.y;
    float rad2 = iMouse.x;
    
    // värit
    vec3 tausta = vec3(0.0, 0.0, 0.0);
    vec3 blue = vec3(0.0, 0.0, 255.0);
    vec3 red = vec3(225.0, 0, 0);

    // Tausta
	vec4 layer1 = vec4(tausta, 1.0);
	
	// Ympyrä 1
	vec4 layer2 = circle(uv, center, rad1 , red);
    
    // Ympyrä 2
    vec2 pos = vec2(100.0, 100.0);
    vec4 layer3 = circle(uv, pos, rad2 , blue);
	
	// Yhdistetään kaikki palautettuun arvoon
	vec4 c = mix(layer1, layer3, layer3.a);
    fragColor = mix(c, layer2, layer2.a);
}
```

Käytetyt tutoriaalit: 
http://fabricecastel.github.io/blog/2016-02-11/main.html
https://www.shadertoy.com/view/Md23DV
https://www.shadertoy.com/view/4lj3WD
Käytin tätä työn pohjana: https://www.shadertoy.com/view/XsjGDt	