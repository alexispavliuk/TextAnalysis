const options = [
    { nameUI: "Number of words", nameMethod : "GetWordsCount" },
    { nameUI: "List of chars in text", nameMethod: "GetListOfChars" },
    { nameUI: "Number of sentences", nameMethod: "GetSentencesCount" },
    { nameUI: "The most common char", nameMethod: "GetMostCommonChar" },
    { nameUI: "Detect language", nameMethod: "DetectLanguage" },
    { nameUI: "Emotionality of the text", nameMethod: "GetEmotionality" },
]

const uri = 'api/textactions';

function createOption(option) {
    return `
    <option value=${option.nameMethod}>${option.nameUI}</option>
`
}

const templatesOption = options.map(option => createOption(option));
const htmlOptions = templatesOption.join(" ");
document.querySelector("select").innerHTML = htmlOptions;



document.getElementById("submit").addEventListener("click", getResult);


function getResult() {
    const text = document.getElementById("text").value;
    const choosedOption = document.getElementById("choosedOption");
    const nameMethod = choosedOption.value;
    const htmlResult = document.getElementById("result");
    htmlResult.innerHTML = "";

    if (text === "") {
        htmlResult.innerHTML = "Please, enter some text";
        return;
    }

    fetch(uri, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            text: text,
            nameMethod: nameMethod
        })
    })
    .then(res => res.text())
    .then(data => {
        htmlResult.innerHTML = data;
    });
}