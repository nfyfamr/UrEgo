# Study Note

## [Tutorial/2D Roguelike Tutorial](https://unity3d.com/kr/learn/tutorials/projects/2d-roguelike-tutorial)
- unity는 2D 모드와 3D 모드를 제공함. 시작할 때 default setting을 2D로 설정할 것.
- 단축키: Q(hand), W(translate), E(rotate), R(scale)
- 오브젝트에 씌울 스프라이트를 해당 오브젝트에  드래그 앤 드롭하면, 해당 오브젝트의 애니메이팅 컨트롤러가 생성된다
- 오브젝트 인스펙터에서 Animation탭의 Controller 항모을 더블클릭하면 컨트롤러구조를 시각화ㅎ여 볼 수 있다.
- 중력등의 기본 물리 시스템 적용을 위해 ‘Rigidbody 3D’ 컴포넌트 추가
- 실제 게임 로직에서 충돌을 확인하기 위해 ‘Box collider 2D’ 컴포너트 추가
- 오브젝트를 프로젝트 트리로 드래그 앤 드롭하면 prefabs이 생성 됨
- 프로젝트 트리에서 ‘Create’ -> ’Animator Override Controller’ 로 다른 컨트롤러를 오버라이딩 할 수 있는 컨트롤러 생성
- 오버라이드할 컨트롤러를 인스펙터의 ‘Controller’ 항목으로 드래그 앤 드롭
- 오버라이드할 메서드도 마찬가지로 드래그 앤 드롭
- 마지막으로 오브젝트 인스펙터에서 오버라이드된 컨트롤럴를 사용하도록 드래그 앤 드롭
- 오브젝트에 정적인 텍스처를 입히기 위해선 ’Sprite Renderer’ 컴포넌트 사용
- 다른 오브젝트를 선택해도 인스펙터 타겟이 바뀌지 않게 하기 위해서 오른쪽 상단의 lock버튼을 사용
- GameManager 오브젝트는 SingleTon 패턴으로 작성되어야 함
- AnimatorController에서 ‘make transition’으로 한 상태에서 다른 상태로 전이 가능함을 나타낼 수 있음
- 스프라이트 애니메이션은 두개의 스프라이트간의 이미지 보정이 불가하기 때문에 Settings > Transition Durations 을 0으로 지정해야 함


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


## [Tutorial/Tilemap](https://www.youtube.com/watch?v=70sLhuE1sbc)
- Hierarchy -> Create -> 2D Object -> Tilemap 으로 Tilemap 오브젝트 생성
- Window -> Tile Pallete 로 타일에디터 창 열기
- 새로운 csscript 파일에 #if-ifend 루틴 안에 MenuItem attribute([MenuItem("Assets/Create/Tiles/WaterTile")])를 추가해서 유니티의 메뉴창을 수정할 수 있다. => script 파일을 추가만해도(실행하지 않아도) 자동으로 읽어들이는 듯.
- 그렇게 만든 WaterTile 애셋에 RefreshTile, GetTileData 메서드를 이용하여 주위 타일에 따라 자동으로 스프라이트를 세팅해주는 코드를 추가
    - RefreshTile: Scene의 Tilemap 오브젝트에 어떠한 인터랙션이 발생할 때마다 refresh가 일어나며, RefreshTile메서드가 불러지는 듯
    - GetTileData: refresh 중에 호출 되는 듯


