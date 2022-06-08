import { Row, Col } from "antd";
import {  Layout } from "antd";

const {Header, Content} = Layout;
function App() {
  return (
    <Layout>
      <Header >
        <Row justify="space-between">
          <Col style={{ color: "white"}}> <span style={{ fontSize: "1.5rem"}}>ITFinder</span> </Col>
          <Col style={{color: "white"}}> <span style={{ fontSize: "1.5rem"}}>Для ІТ-фахівців 💻</span> </Col>

        </Row>
      </Header> 
      <Content>
        <Row justify="center" style={{paddingTop: "6vw", paddingBottom: "6vw", backgroundColor: "blue"}} >
        <Col span={12}>
            <Row justify="center"> <span style={{fontSize: "3rem", marginBottom: "2rem", fontWeight: "bold"}}>Пошук роботи в ІТFinder 🔍</span> </Row>
            <Row justify="center"> <span style={{fontSize: "2rem", textAlign: "center"}}>Опишіть власні навички, досвід та зарплатні очікування. Компанії викладають вакансії і лише Ви вирішуєте на чию пропозицію відгукнутись!</span> </Row>
          </Col>
        </Row>

        <Row justify="center" style={{paddingTop: "6vw", paddingBottom: "6vw", backgroundColor: "yellow"}}>
          <Col span={12}>
            <Row justify="center"> <span style={{fontSize: "3rem", textAlign: "center", marginBottom: "2rem" ,fontWeight: "bold"}}>Чому ITFinder? 🤔</span> </Row>
            <Row justify="center"> <span style={{fontSize: "2rem", textAlign: "center"}}>ITFinder надає можливість анонімного пошуку без зайвих клопотів та упередженостей! Шукають в першу чергу Вас! Бо саме Ви є рушієм ринку, адже досвідчені фахівці завжди користуються широким попитом.</span> </Row>
          </Col>
        </Row>

        <Row justify="center" style={{paddingTop: "6vw", paddingBottom: "6vw", backgroundColor: "blue"}}>
          <Col span={12}>
            <Row justify="center"> <span style={{fontSize: "3rem", textAlign: "center", marginBottom: "2rem", fontWeight: "bold"}}>Скільки пропозицій отримаю? 💼</span> </Row>
            <Row justify="center"> <span style={{fontSize: "2rem", textAlign: "center"}}>IЗалежить від вашого технологічного стеку, очікувань та виду роботи.</span> </Row>
          </Col>
        </Row>



        <Row justify="center" style={{paddingTop: "6vw", paddingBottom: "6vw", backgroundColor: "yellow"}}>
          <Col span={12}>
            <Row justify="center"> <span style={{fontSize: "3rem", textAlign: "center", marginBottom: "2rem", fontWeight: "bold"}}>Мій роботодавець може мене знайти у ITFinder? 🥷🏻</span> </Row>
            <Row justify="center"> <span style={{fontSize: "2rem", textAlign: "center"}}>Ні. Повна анонімність - наша мета. Роботодавець пропонує Вам вакансію або ж ви відгукуєтесь на неї без відкриття ваших контактів.</span> </Row>
          </Col>
        </Row>

        <Row justify="center" style={{paddingTop: "6vw", paddingBottom: "6vw", backgroundColor: "blue"}}>
          <Col span={12}>
            <Row justify="center"> <span style={{fontSize: "3rem", textAlign: "center", marginBottom: "2rem", fontWeight: "bold"}}>Наймайте працівників через ITFinder 🪄</span> </Row>
            <Row justify="center"> <span style={{fontSize: "2rem", textAlign: "center"}}>Ви нічого не сплачуєте за найм кандидата. Для підвищення пріоритетності є можливість просування вакансій компанії за фіксовану щомісячну плату.</span> </Row>
          </Col>
        </Row>

        <Row justify="center" style={{paddingTop: "6vw", paddingBottom: "6vw", backgroundColor: "yellow", fontWeight: "bold"}}>
          <Col span={12}>
            <Row justify="center"><a style={{ backgroundColor: "blue", fontSize: "2rem", color: "white", padding: "1.25rem", borderRadius: "1.5rem"}} href="/#">Почати пошук 🌏</a></Row>
          </Col>
        </Row>

        <Row justify="center" style={{paddingTop: "6vw", backgroundColor: "blue"}}>
          <Col span={8}>
            <Row justify="center">
            <span style={{ margin: "1rem"}}><img src="https://www.svgrepo.com/show/111199/instagram.svg" width={50} height={50} alt="" /></span>
            <span style={{ margin: "1rem"}}><img src="https://www.svgrepo.com/show/354443/telegram.svg" width={50} height={50} alt="" /></span>
             <span style={{ margin: "1rem"}}><img src="https://www.svgrepo.com/show/17588/mail.svg" width={50} height={50} alt="" /></span>
      
            </Row>
          
          </Col>
        </Row>
      </Content>
  
    </Layout>
  );
}

export default App;
