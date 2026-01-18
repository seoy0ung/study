c// 1. Falsy한 값
let f1 = undefined;
let f2 = null;
let f3 = 0;
let f4 = -0;
let f5 = NaN;
let f6 = "";
let f7 = 0n;
// 조건문에서 false로 평가되는 값들

// 2. Truthy한 값
// -> Falsy한 값을 제외한 모든 값
let t1 = "hello";
let t2 = 123;
let t3 = {};
let t4 = [];
let t5 = () => { };

// 3. 활용 사례

function printName(person) {
    if(person === undefined || person === null) {
        console.log("이름이 없습니다.");
        return;
    }
    console.log(person.name);
}

let person = null;
printName(person);
