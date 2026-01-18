//1. 함수 표현식 -> 호이스팅이 안됨

function funcA() {
    console.log("funcA")
}

let varA = funcA;
varA();

// 익명함수
let varB = function () { 
    console.log("funcB");
};

// 2. 화살표 함수
let varC = (value) => value + 1;

let varD = (value) => {
    console.log(value)
    return value + 1;
};

console.log(varC(10));

