const options = [
    { nameUI: "Number of words", nameMethod : "GetWordsCount" },
    { nameUI: "List of chars in text", nameMethod: "GetListOfChars" },
    { nameUI: "Number of sentences", nameMethod: "GetSentencesCount" },
    { nameUI: "The most common char", nameMethod: "GetMostCommonChar" }
]

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

    try {
        const uri = 'api/textactions';
        //const response = fetch(uri, {
        //    method: 'post',
        //    body: [ text, nameMethod ]
        //});
        
    }
    catch (error) {

    }
}