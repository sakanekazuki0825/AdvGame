using UnityEngine;
using UnityEngine.UI;

// �A�h�x���`���[��\������L�����o�X
public class AdventureCanvas : CanvasBase, IAdventureCanvas
{
	// ���݂̃A�h�x���`���[
	AdventureBase adventure;

	// �w�i�摜
	[SerializeField]
	Image backGroundImg;

	// �L�����N�^�[�摜
	[SerializeField]
	Image characterImg;

	/// <summary>
	/// �A�h�x���`���[�ݒ�
	/// </summary>
	/// <param name="adventure">�ݒ肷��A�h�x���`���[</param>
	void IAdventureCanvas.SetAdventure(AdventureBase adventure)
	{
		this.adventure = adventure;
		// �w�i�ݒ�
		backGroundImg.sprite = adventure.backGroundSprite;
		// �����\��
		MainMessageText.Instance.TextDisplay(adventure.messagese[0]);
	}
}
