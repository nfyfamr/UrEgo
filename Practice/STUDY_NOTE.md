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

## [Tutorial/unity for 2D](https://unity3d.com/kr/learn/tutorials/topics/2d-game-creation/2d-game-development-walkthrough?playlist=17093)
