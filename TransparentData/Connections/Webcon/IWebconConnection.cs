using TransparentData.Models.Webcon;

namespace TransparentData.Connections.Webcon
{
    public interface IWebconConnection
    {
        public Element GetElement(int elementID);

        public Responce PatchElement(int elementID, Element element);
        public Responce PostAttachment(int elementID, Attachment element);
    }
}
