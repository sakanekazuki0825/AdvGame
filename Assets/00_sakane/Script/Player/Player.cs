using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

// �v���C���[�N���X
public class Player : MonoBehaviour
{
	// ����
	MainInput input;

	// true = UI�ɃJ�[�\�������킹�Ă���
	bool isOnUI = false;

	void Start()
	{
		// ���̓V�X�e������
		input = new MainInput();
		// ���̓V�X�e���L����
		input.Enable();
		// ���͂ɂ�锽���ݒ�
		input.Player.NextMessage.started += Input;
	}

	private void OnEnable()
	{
		// ���͗L����
		input?.Enable();
	}

	private void Update()
	{
		isOnUI = EventSystem.current.IsPointerOverGameObject();
	}

	private void OnDisable()
	{
		// ���͖�����
		input.Disable();
	}

	private void OnDestroy()
	{
		input.Player.NextMessage.started -= Input;
	}

	void Input(InputAction.CallbackContext context)
	{
		// �I�u�W�F�N�g�ɃJ�[�\���������Ă���ꍇ���͖���
		if (isOnUI)
		{
			return;
		}
		AdventureManager.Instance.NextCut();
	}
}