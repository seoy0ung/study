//배열

// 1. 배열 생성
let arrA = new Array(); // 배열 생성자
let arrB = []; // 배열 리터럴 (대부분 사용)

let arrC = [1, 2, 3,
    true, "hello", null, undefined, {}, function () { }
];

// 2. 배열 요소 접근
let item1 = arrC[0]; // 1
let item2 = arrC[4]; // "hello"

arrC[0] = "hello"; // 요소 수정
console.log(arrC);
