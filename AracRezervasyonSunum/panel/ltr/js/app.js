var selectedOption = document.querySelector(".selected-option");
var options = document.querySelectorAll(".option");

selectedOption.addEventListener("click", () => {
    selectedOption.parentElement.classList.toggle("active");
});

options.forEach((option) => {
    option.addEventListener("click", () => {
        setTimeout(() => {
            selectedOption.innerHTML = option.innerHTML;
        }, 300);

        selectedOption.parentElement.classList.remove("active");
    });
});