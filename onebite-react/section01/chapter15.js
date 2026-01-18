//1. 객체 생성
let obj1 = new Object(); // 객체 생성자
let obj2 = {}; // 객체 리터럴(대부분 이거씀)

//2. 객체 프로퍼티(속성) => key:value
let person = {
    name : "홍길동",
    age : 20,
    hobby : "테니스",
    job : "FE 개발자",
    extra : {},
    10 : 20,
    "like cat" : true,
};


// 3. 객체 프로퍼티를 다루는 방법
// 3-1. 프로퍼티 접근 방법 (점 표기법, 괄호 표기법)
let name = person.name; // 점 표기법
let age = person["age"]; // 괄호 표기법
let cat = person["like cat"]; // 띄어쓰기 있을 때는 무조건 괄호 표기법
// 존재하지 않는 프로퍼티에 접근하려고 하면 undefined 반환

let property = "hobby";
let hobby = person[property]; // 변수로 접근 가능(괄호 표기법)
// 동적으로 꺼내올 때는 괄호표기법이 유용함
// 그걸 제외하곤 점표기법이 간편


// 3-2. 새로운 프로퍼티를 추가하는 방법
person.job = "fe developer"; // 점 표기법
person["favoriteFood"] = "pizza"; // 괄호 표기법

// 3-3. 프로퍼티 수정
person.job = "fullstack developer";
person["age"] = 21;

// 3-4. 프로퍼티 삭제
delete person.job;
delete person["like cat"];

// 3-5. 프로퍼티 존재 여부 확인 (in 연산자)
let result1 = "name" in person; // true
let result2 = "job" in person; // false
