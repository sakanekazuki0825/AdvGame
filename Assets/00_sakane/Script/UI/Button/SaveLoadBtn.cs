using UnityEngine;
using UnityEngine.UI;

// �ۑ��ǂݍ��݃{�^��
public class SaveLoadBtn : MonoBehaviour
{
	// �摜
	Image image;

	private void Start()
	{
		// �摜�擾
		image = GetComponent<Image>();
	}

	/// <summary>
	/// ������
	/// </summary>
	public void Init()
	{

	}

	/// <summary>
	/// �{�^���̐ݒ�
	/// </summary>
	/// <param name="sprite">�ݒ肷��摜</param>
	public void SetButton(Sprite sprite)
	{
		// �摜�ݒ�
		image.sprite = sprite;
	}

	/// <summary>
	/// �N���b�N
	/// </summary>
	public void Click()
	{

	}
}