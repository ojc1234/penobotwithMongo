# penobot
발음을 표현하는 봇
config/config.json 파일에 자신에 봇토큰을 넣고 config.cs파일에 파일경로를 넣어줍니다.
http://aha-dic.com/ 이사이트를 이용하고 있습니다

기여해주면 좋을지도

이용라이브러리
Newtonsoft.Json
Discord.Net
HtmlAgilityPack.NetCore
문의 discord에서 노니#2196로 dm주세요

### '빌드전에 나무위키 보고가세요'
"https://namu.wiki/w/Discord/%EB%B4%87/%EC%A0%9C%EC%9E%91%EB%B2%95"
</br>
## 사용법
***
![image](https://cdn.discordapp.com/attachments/990865868139425842/1069284753490059294/image.png)
![image](https://cdn.discordapp.com/attachments/919471254669496331/1069968003418034226/image.png)
</br>

빌드방법(닷넷 7.0 윈도우 기준)
***

1. config/token.cs 파일에서 FileRoute변수에
자신의 토큰이 적혀있는 파일에 경로를 복사해서 붙혀넣기 하세요

2. program.cs 파일에 setting 값을 바꿔서 원하는 설정으로 바꾸세요 기본값 0

3. 프로젝트 디렉토리에서 <b>dotnet build</b>를 입력하면 \bin\Debug\net7.0-windows 경로에 penodiscordbot.exe폴더가 있습니다 그파일을 실행하시면 디코봇이 작동합니다.
</br>
추가예정 
</br>
단어를 디비를 통해 저장할수 있음
디비에 있는 단어들을 통해 문제를 풀수 있음
단어장 인베드 보낼 때 페이지 구현