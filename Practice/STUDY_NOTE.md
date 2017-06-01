# Study Note

## [Tutorial/2D Roguelike Tutorial](https://unity3d.com/kr/learn/tutorials/projects/2d-roguelike-tutorial)

## [Tutorial/Unity 5 2D Platformer Tutorial](https://www.youtube.com/watch?v=oK_NzdVSxaQ)
- 애니메이션 전이 중 Has Exit Time은 진행중인 애니메이션을 도중에 중단하고 다음 애니메이션으로 넘어갈지, 진행중인 애니메이션을 끝까지 재생하고 넘어갈지를 결정
- 2D 콜리더끼리의 충돌 갭의 크기를 조절: Edit -> Project Settings -> Physics 2D -> Min Penetration For Penalty
- gameObject는 스크립트가 적용된 오브젝트를 가리킨다?
- 일시정지 화면 추가
    - Scene -> UI -> Canvas
    - Render Mode -> Screen Space - Camera
    - Render Camera 에 기존 카메라 추가
    - Order in Layer 늘리기 (그래야 다른 오브젝트 위에서 보임) 
- 일시정지 화면에서의 버튼들 이벤트 할당
    - 오브젝트는 메인카메라로 설정 (일종의 유지되어야 하는 오브젝트 설정 같음)
    - 실행할 함수는 스크립트에서 정의한 함수들에서 지정
    - Restart, MainMenu 함수같은 경우 Application.LoadLevel 함수를 사용하게 되는데, 이는 일종의 화면의 인덱스 같음
- 트랩의 콜라이더는 트리거 설정하기
- gameObject.GetComponent<Animation> ().Play ("Player_RedFlash"); 로 애니메이션 실행할 수 있음. 애니메이션이 실행 되지 않을 때, 프리펍을 누르고 옵션에서 Debug 모드로 전환 -> Legacy를 체크한다 (다시 노멀모드로 돌아올 것)



## [Tutorial/unity for 2D](https://unity3d.com/kr/learn/tutorials/topics/2d-game-creation/2d-game-development-walkthrough?playlist=17093)
