
# PowerWords

PowerWords permite busca do significados de diversas palavras da lingua portuguesa. Todos os dados são obtidos do [Dicio](https://www.dicio.com.br/).


## Documentação da API

#### Retorna o significado, a classe gramatical e a etimologia

```http
  GET /{word}
```

****Response****
```
{
    "status": string,
    "data": {
        "word": string,
        "grammarClass": string,
        "meanings": string[],
        "etymology": string
    }
}
```




## Uso/Exemplos

Vamos usar a palavra paupérrimo para fazermos uma demonstração


https://powerwords-dev-maqf.4.us-1.fl0.io/pauperrimo
```http
    GET /pauperrimo
```

****Response****
```
{
    "status": "Sucesso",
    "data": {
        "word": "pauperrimo",
        "grammarClass": "adjetivo",
        "meanings": [
            "Característica de algo ou de alguém extremamente pobre;
             sem recursos financeiros, 
             dinheiro ou bens materiais: morava num barraco paupérrimo;
             era um sujeito paupérrimo."
        ],
        "etymology": "Etimologia (origem da palavra paupérrimo). Do latim pauperrimus."
    }
}
```


## Autores

- [KingOfTheHunt](https://github.com/KingOfTheHunt)


## Stack utilizada

**Back-end:** .NET, C#, ASP.NET 

