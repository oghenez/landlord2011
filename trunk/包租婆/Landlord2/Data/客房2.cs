using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////

    public partial class �ͷ�
    {
        public static �ͷ� MyCreate()
        {
            return new �ͷ�() { ID = Guid.NewGuid(), ֧������ = 3 };
        }

    }

   
}
