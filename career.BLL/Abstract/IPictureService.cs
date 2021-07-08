using career.DTO;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface IPictureService
    {
        PictureForAddDto AddPicture(PictureForAddDto pictureForAddDto);
        PictureForUpdateDto UpdatePicture(PictureForUpdateDto pictureForUpdateDto);
        void Delete(int id);
    }
}
