using System;

namespace SapService
{
	/// <summary>
	/// privilidge ��ժҪ˵����
	/// </summary>
	public struct privilidge
	{
		public string PrintBin ;//��ӡ��λ
		public string PrintLabel;//��ӡ���ϱ�ǩ
		public string CGSH;//�ɹ��ջ�
		public string CGRK;//�ɹ����
		public string DGRK;//�������
		public string YCRK;//�쳣���
		public string PANDIAN;//�̵�
		public string YK; //�ƿ�
		public string SCLL;//��������
		public string BF; //����
		public string TH; //�˻�
		public string CX;// �ֿ���Ϣ��ѯ
		public string DGCK;//���ܳ���
		public string SJ;//�ϼ�
		public string DBGCK;//�����ܳ���
		public string BYD;//�鿴������
		public string HWCX;//��λ��ѯ
		public string PCCX;//���β�ѯ
		public string KCTH;//����˻�
		public string DJKTH;//������˻�

		/// <summary>
		/// �Ƿ��ǹ���Ա
		/// </summary>
		public bool isAdmin;

//		/// <summary>
//		/// �û��Ƿ���Ч
//		/// </summary>
//		public bool isInEffect;

		/// <summary>
		/// ��������ǰʱ�䣬����ͬ��ɨ��ǹ�ϵ�ʱ�� myl 2008-09-04
		/// </summary>
		public System.DateTime ServerTime;
	}
}
